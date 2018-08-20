using Job.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Job.Data.Repositories.Interfaces
{
    public interface IVersionRepository
    {
        Task<IEnumerable<VersionInfo>> Get();

        Task<VersionInfo> GetLast(DataType dataType);

        Task Add(VersionInfo versionInfo);

        Task Remove(VersionInfo versionInfo);

        Task Update(VersionInfo versionInfo);
    }
}
