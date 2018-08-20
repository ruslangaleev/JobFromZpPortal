using Job.Data.Repositories.Interfaces;
using Job.Services.Clients.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Job.Services.Services.Logic
{
    public class JobManager : IJobManager
    {
        private readonly IRubricRepository _rubricRepository;
        private readonly IZpClient _zpClient;

        public JobManager(IRubricRepository rubricRepository, IZpClient zpClient)
        {
            _rubricRepository = rubricRepository ?? throw new ArgumentNullException(nameof(rubricRepository));
            _zpClient = zpClient ?? throw new ArgumentNullException(nameof(zpClient));
        }

        public async Task UpdateRubrics()
        {
            var rubrics = await _zpClient.GetRubrics();
            await _rubricRepository.AddRange(rubrics);
        }
    }
}
