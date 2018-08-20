using Job.Data.Models;
using Job.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Job.Data.Repositories.Logic
{
    public class VacancyRepository : IVacancyRepository
    {
        public Task AddRange(IEnumerable<Vacancy> vacancies)
        {
            return null;
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vacancy>> Get()
        {
            return null;
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vacancy>> Get(Guid rubricId)
        {
            return null;
            throw new NotImplementedException();
        }

        public Task Remove(Guid versionId)
        {
            return null;
            throw new NotImplementedException();
        }

        public Task RemoveRange(IEnumerable<Vacancy> vacancies)
        {
            return null;
            throw new NotImplementedException();
        }
    }
}
