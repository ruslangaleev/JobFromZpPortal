using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Job.Data.Models;
using Job.Data.Repositories.Interfaces;
using Job.Services.Services.Interfaces;
using Job.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Job.Controllers
{
    [Route("api/vacancies")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private IVacancyManager _vacancyManager;
        private IVersionRepository _versionRepository;

        public VacancyController(IVacancyManager vacancyManager, IVersionRepository versionRepository)
        {
            _vacancyManager = vacancyManager ?? throw new ArgumentNullException(nameof(vacancyManager));
            _versionRepository = versionRepository ?? throw new ArgumentNullException(nameof(versionRepository));
        }

        /// <summary>
        /// Возвращает список вакансий.
        /// </summary>
        /// <param name="limit">Количество результатов на странице (≤ 100, по умолчанию: 10).</param>
        /// <param name="offset">Начальный сдвиг возвращаемых результатов (≤ 10000).</param>
        [HttpGet]
        public async Task<object> Get(int limit = 10, int offset = 0)
        {
            var versionInfo = await _versionRepository.GetLast(DataType.Vacancy, true);
            if (versionInfo == null)
            {
                versionInfo = await _versionRepository.GetLast(DataType.Vacancy);
                if (versionInfo == null)
                {
                    return Ok(new VacancyInfoViewModel
                        {
                            Count = 0,
                            Limit = limit,
                            Offset = offset,
                            Vacancies = new List<Vacancy>()
                        });
                }
            }

            if (limit > 100) { limit = 100; }

            if (limit < 0) { limit = 10; }

            if (offset < 0) { offset = 0; }

            var offsetEnd = (int)(versionInfo.CountDownloded / limit);
            if (offset > offsetEnd)
            {
                offset = offsetEnd - 1;
            }

            var vacancies = await _vacancyManager.GetVacancies(versionInfo.VersionInfoId, limit, offset);
            return Ok(new VacancyInfoViewModel
            {
                Count = versionInfo.CountDownloded,
                Limit = limit,
                Offset = offset,
                Vacancies = vacancies
            });
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await _vacancyManager.UpdateVacancies();

            return Ok("Выполняется обновление вакансий");
        }
    }
}
