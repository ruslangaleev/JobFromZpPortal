using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Job.Data
{
    /// <summary>
    /// Единица работы с БД
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Сохраняет изменения в БД
        /// </summary>
        Task SaveChangesAsync();
    }
}
