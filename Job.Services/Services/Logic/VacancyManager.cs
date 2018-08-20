using Job.Data.Models;
using Job.Data.Repositories.Interfaces;
using Job.Services.Clients.Interfaces;
using Job.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Services.Services.Logic
{
    public class VacancyManager : IVacancyManager
    {
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IZpClient _zpClient;
        private readonly IVersionRepository _versionRepository;

        public VacancyManager(IVacancyRepository vacancyRepository, IVersionRepository versionRepository, IZpClient zpClient)
        {
            _vacancyRepository = vacancyRepository ?? throw new ArgumentNullException(nameof(vacancyRepository));
            _zpClient = zpClient ?? throw new ArgumentNullException(nameof(zpClient));
            _versionRepository = versionRepository ?? throw new ArgumentNullException(nameof(versionRepository));
        }

        public async Task UpdateVacancies()
        {
            var currentVersionInfo = await _versionRepository.GetLast(DataType.Vacancy);
            if (currentVersionInfo != null)
            {
                // Если в предыдущей версии не все вакансии были закачены
                if (!currentVersionInfo.IsDownloaded)
                {
                    await _vacancyRepository.Remove(currentVersionInfo.VersionInfoId);
                    await _versionRepository.Remove(currentVersionInfo);
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
                    versionInfo.Count = vacancyInfo.Count;
                    // SaveChange
                }

                vacancyInfo.Vacancies.ToList().ForEach(t => t.VersionId = versionInfo.VersionInfoId);

                await _vacancyRepository.AddRange(vacancyInfo.Vacancies);

                offset += 100;
                versionInfo.CountDownloded += 100;
                // SaveChange
            }
            while (versionInfo.Count > offset);

            // Уд
            currentVersionInfo = await _versionRepository.GetLast(DataType.Vacancy);
            if (currentVersionInfo != null)
            {
                if (currentVersionInfo.IsDownloaded)
                {
                    await _vacancyRepository.Remove(currentVersionInfo.VersionInfoId);
                    await _versionRepository.Remove(currentVersionInfo);
                    currentVersionInfo.IsRemoved = true;
                    await _versionRepository.Update(currentVersionInfo);
                }
            }
        }
    }
}
