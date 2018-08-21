using Job.Data.Models;
using System.Collections.Generic;

namespace Job.Services.ViewModels
{
    /// <summary>
    /// Модель для вывода списка вакансий.
    /// </summary>
    public class VacancyInfoViewModel
    {
        /// <summary>
        /// Количество результатов на странице.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Начальный сдвиг возвращаемых результатов.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Количество вакансий.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Список вакансий.
        /// </summary>
        public IEnumerable<Vacancy> Vacancies { get; set; }
    }
}
