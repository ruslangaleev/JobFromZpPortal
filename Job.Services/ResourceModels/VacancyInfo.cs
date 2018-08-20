using Job.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Job.Services.ResourceModels
{
    public class VacancyInfo
    {
        public int Count { get; set; }

        public string ErrorMessage { get; set; }

        public IEnumerable<Vacancy> Vacancies { get; set; }
    }
}
