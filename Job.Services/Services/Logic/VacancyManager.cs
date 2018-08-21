using Job.Data;
using Job.Data.Models;
using Job.Data.Repositories.Interfaces;
using Job.Services.Clients.Interfaces;
using Job.Services.Services.Interfaces;
using Job.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job.Services.Services.Logic
{
    public class VacancyManager : IVacancyManager
    {
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IZpClient _zpClient;
        private readonly IVersionRepository _versionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VacancyManager(IUnitOfWork unitOfWork, IVacancyRepository vacancyRepository, IVersionRepository versionRepository, IZpClient zpClient)
        {
            _vacancyRepository = vacancyRepository ?? throw new ArgumentNullException(nameof(vacancyRepository));
            _zpClient = zpClient ?? throw new ArgumentNullException(nameof(zpClient));
            _versionRepository = versionRepository ?? throw new ArgumentNullException(nameof(versionRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<Vacancy>> GetVacancies(Guid versionInfoId, int limit = 25, int offset = 0)
        {
            return await _vacancyRepository.GetVacancies(versionInfoId, limit, offset);
        }

        public async Task<IEnumerable<Vacancy>> GetVacancies(Guid rubricId)
        {
            return await _vacancyRepository.Get(rubricId);
        }

        public async Task UpdateVacancies()
        {
            // Проверяем последнюю версию обновлений
            var currentVersionInfo = await _versionRepository.GetLast(DataType.Vacancy);
            if (currentVersionInfo != null)
            {
                // Если в предыдущей версии не все вакансии были закачены
                if (!currentVersionInfo.IsDownloaded)
                {
                    // Удаляем все и заводим новую версию
                    await _vacancyRepository.Remove(currentVersionInfo.VersionInfoId);
                    _versionRepository.Remove(currentVersionInfo);
                    await _unitOfWork.SaveChangesAsync();
                }
            }

            var versionInfo = new VersionInfo
            {
                UpdateAt = DateTime.Now,
                DataType = DataType.Vacancy,
            };

            await _versionRepository.Add(versionInfo);
            
            int offset = 0;

            do
            {
                var vacancyInfo = await _zpClient.GetVacancies(offset: offset);
                if (versionInfo.Count == 0)
                {
                    versionInfo.Count = vacancyInfo.Metadata.ResultSet.Count;
                    // SaveChange
                    await _unitOfWork.SaveChangesAsync();
                }

                var vacancies = new List<Vacancy>();
                foreach(var entry in vacancyInfo.Vacancies)
                {
                    vacancies.Add(new Vacancy
                    {
                        Salary = entry.Salary,
                        VersionId = versionInfo.VersionInfoId,
                        Description = entry.Description,
                        Header = entry.Header,
                        PositionTitle = entry.Header,
                        Url = entry.CanonicalUrl
                    });
                }

                await _vacancyRepository.AddRange(vacancies);
                
                offset += 100;
                versionInfo.CountDownloded += 100;
                // SaveChange
                await _unitOfWork.SaveChangesAsync();
            }
            while (versionInfo.Count > offset);

            // Уд
            currentVersionInfo = await _versionRepository.GetLast(DataType.Vacancy);
            if (currentVersionInfo != null)
            {
                if (currentVersionInfo.IsDownloaded)
                {
                    await _vacancyRepository.Remove(currentVersionInfo.VersionInfoId);
                    _versionRepository.Remove(currentVersionInfo);
                    currentVersionInfo.IsRemoved = true;
                    await _versionRepository.Update(currentVersionInfo);
                }
            }
        }
    }
}
