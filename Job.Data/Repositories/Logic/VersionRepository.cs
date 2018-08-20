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
            return null;
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VersionInfo>> Get()
        {
            return null;
            throw new NotImplementedException();
        }

        public Task<VersionInfo> GetLast(DataType dataType)
        {
            return null;
            throw new NotImplementedException();
        }

        public Task Remove(VersionInfo versionInfo)
        {
            return null;
            throw new NotImplementedException();
        }

        public Task Update(VersionInfo versionInfo)
        {
            return null;
            throw new NotImplementedException();
        }
    }
}
