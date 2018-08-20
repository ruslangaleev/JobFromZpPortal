using Job.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job.Data.Repositories.Interfaces
{
    public interface IVacancyRepository
    {
        Task<IEnumerable<Vacancy>> Get();

        Task AddRange(IEnumerable<Vacancy> vacancies);

        Task RemoveRange(IEnumerable<Vacancy> vacancies);

        Task Remove(Guid versionId);
    }
}
