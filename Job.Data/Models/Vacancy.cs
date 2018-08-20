using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Job.Data.Models
{
    public class Vacancy
    {
        public Guid VersionId { get; set; }
        
        public string Salary { get; set; }

        public string PositionTitle { get; set; }

        public string Url { get; set; }

        public string Header { get; set; }

        public string Description { get; set; }
    }
}
