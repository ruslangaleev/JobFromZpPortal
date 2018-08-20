using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Job.Data
{
    /// <summary>
    /// Единица работы с БД.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        protected DatabaseContext DataContext
        {
            get { return _databaseContext; }
        }

        /// <summary>
        /// Сохраняет изменения в БД.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await DataContext.SaveChangesAsync();
        }
    }
}
