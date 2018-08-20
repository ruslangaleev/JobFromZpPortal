using Job.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Job.Services.Services.Interfaces
{
    public interface IVacancyManager
    {
        Task<IEnumerable<Vacancy>> GetVacancies();

        Task<IEnumerable<Vacancy>> GetVacancies(Guid rubricId);

        Task UpdateVacancies();
    }
}
