using Job.Data.Models;
using Job.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Data.Repositories.Logic
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly DbSet<Vacancy> _vacancies;
        private readonly DatabaseContext _databaseContext;

        public VacancyRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _vacancies = databaseContext.Set<Vacancy>();
        }

        public async Task AddRange(IEnumerable<Vacancy> vacancies)
        {
            await _vacancies.AddRangeAsync(vacancies);
        }

        public async Task<IEnumerable<Vacancy>> GetVacancies(Guid versionInfoId, int limit = 25, int offset = 0)
        {
            return await _vacancies
                .Where(t => t.VersionId == versionInfoId)
                .Skip(offset * limit)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<Vacancy>> Get(Guid rubricId)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(Guid versionId)
        {
            //var vacancy = new Vacancy
            //{
            //    VersionId = versionId
            //};

            //_vacancies.AttachRange(vacancy);
            //_vacancies.RemoveRange(vacancy);

            try
            {
                await _databaseContext.Database.ExecuteSqlCommandAsync($"DELETE FROM public.\"Vacancies\" WHERE \"VersionId\" = {versionId}");
            }
            catch(Exception e)
            {
                var t = e;
            }
        }

        //public Task RemoveRange(IEnumerable<Vacancy> vacancies)
        //{
        //    return null;
        //    throw new NotImplementedException();
        //}
    }
}
