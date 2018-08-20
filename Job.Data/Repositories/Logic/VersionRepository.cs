using Job.Data.Models;
using Job.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Job.Data.Repositories.Logic
{
    public class VersionRepository : IVersionRepository
    {
        public Task Add(VersionInfo versionInfo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VersionInfo>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<VersionInfo> GetLast(DataType dataType)
        {
            throw new NotImplementedException();
        }

        public Task Remove(VersionInfo versionInfo)
        {
            throw new NotImplementedException();
        }

        public Task Update(VersionInfo versionInfo)
        {
            throw new NotImplementedException();
        }
    }
}
