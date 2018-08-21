using Job.Data.Models;
using Job.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Job.Services.Services.Interfaces
{
    public interface IVacancyManager
    {
        Task<IEnumerable<Vacancy>> GetVacancies(Guid versionId, int limit = 25, int offset = 0);

        Task<IEnumerable<Vacancy>> GetVacancies(Guid rubricId);

        Task UpdateVacancies();
    }
}
