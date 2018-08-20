using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Job.Data.Models;
using Job.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Job.Controllers
{
    [Route("api/vacancies")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private IVacancyManager _vacancyManager;

        /// <summary>
        /// Провайдер для получения зависимостей.
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        public VacancyController(IVacancyManager vacancyManager)
        {
            _vacancyManager = vacancyManager ?? throw new ArgumentNullException(nameof(vacancyManager));
        }

        [HttpGet]
        public async Task<IEnumerable<Vacancy>> Get()
        {
            return await _vacancyManager.GetVacancies();
        }
        
        [HttpGet("{rubricId}")]
        public async Task<IEnumerable<Vacancy>> Get(Guid rubricId)
        {
            return await _vacancyManager.GetVacancies(rubricId);
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
