using Job.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job.Data.Repositories.Interfaces
{
    public interface IVacancyRepository
    {
        Task<IEnumerable<Vacancy>> Get(Guid rubricId);

        Task<IEnumerable<Vacancy>> Get(int limit = 25, int offset = 0);

        Task AddRange(IEnumerable<Vacancy> vacancies);

        //Task RemoveRange(IEnumerable<Vacancy> vacancies);

        Task Remove(Guid versionId);
    }
}
