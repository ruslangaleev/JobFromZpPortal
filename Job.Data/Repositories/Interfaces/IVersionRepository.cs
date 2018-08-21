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

        /// <summary>
        /// Возвращает последнюю версию обновлений.
        /// </summary>
        /// <param name="dataType">Вид данных.</param>
        /// <param name="isDownloaded">
        /// Если true, то предоставит только ту версию, в которых данных были полностью загружены.
        /// Если false, то предоставит просто последнию версию.</param>
        Task<VersionInfo> GetLast(DataType dataType, bool isDownloaded = false);

        Task Add(VersionInfo versionInfo);

        void Remove(VersionInfo versionInfo);

        Task Update(VersionInfo versionInfo);
    }
}
