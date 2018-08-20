using Job.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Job.Services.Clients.Interfaces
{
    public interface IZpClient
    {
        Task<IEnumerable<Rubric>> GetRubrics();
    }
}
