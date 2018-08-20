using Job.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Job.Data.Repositories.Interfaces
{
    public interface IRubricRepository
    {
        Task AddRange(IEnumerable<Rubric> rubrics);
    }
}
