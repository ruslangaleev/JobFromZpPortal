using Job.Data.Models;
using Job.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Job.Data.Repositories.Logic
{
    public class VersionRepository : IVersionRepository
    {
        private readonly DbSet<VersionInfo> _versions;
        private readonly DatabaseContext _databaseContext;

        public VersionRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _versions = databaseContext.Set<VersionInfo>();
        }

        public async Task Add(VersionInfo versionInfo)
        {
            await _versions.AddAsync(versionInfo);
        }

        public Task<IEnumerable<VersionInfo>> Get()
        {
            return null;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает последнюю версию обновлений.
        /// </summary>
        /// <param name="dataType">Вид данных.</param>
        /// <param name="isDownloaded">
        /// Если true, то предоставит только ту версию, в которых данных были полностью загружены.
        /// Если false, то предоставит просто последнию версию.</param>
        public async Task<VersionInfo> GetLast(DataType dataType, bool isDownloaded = false)
        {
            if (isDownloaded)
            {
                return await _versions.LastOrDefaultAsync(t => t.DataType == dataType && t.IsDownloaded);
            }

            return await _versions.LastOrDefaultAsync(t => t.DataType == dataType);
        }

        public void Remove(VersionInfo versionInfo)
        {
            _versions.Remove(versionInfo);
        }

        public Task Update(VersionInfo versionInfo)
        {
            return null;
            throw new NotImplementedException();
        }
    }
}
