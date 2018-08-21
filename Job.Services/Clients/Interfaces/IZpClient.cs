using Job.Data.Models;
using Job.Services.ResourceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Job.Services.Clients.Interfaces
{
    public interface IZpClient
    {
        Task<IEnumerable<Rubric>> GetRubrics();

        Task<VacancyInfo> GetVacancies(int limit = 100, int offset = 0);
    }
}
