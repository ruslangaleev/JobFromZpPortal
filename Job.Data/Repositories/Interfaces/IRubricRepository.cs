using Job.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Job.Data.Repositories.Interfaces
{
    public interface IRubricRepository
    {
        Task<IEnumerable<Rubric>> Get();

        Task AddRange(IEnumerable<Rubric> rubrics);

        Task RemoveRange(IEnumerable<Rubric> rubrics);
    }
}
