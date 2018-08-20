using Job.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Job.Services.ResourceModels
{
    public class VacancyInfo
    {
        public Metadata Metadata { get; set; }
        
        public IEnumerable<VacancyInformation> Vacancies { get; set; }
    }

    public class Metadata
    {
        public ResultSet ResultSet { get; set; }
    }

    public class ResultSet
    {
        public int Count { get; set; }
    }

    public class VacancyInformation
    {
        public string Salary { get; set; }

        [JsonProperty("position_dictionary")]
        public PositionDictionary positionDictionary { get; set; }

        [JsonProperty("canonical_url")]
        public string CanonicalUrl { get; set; }
        
        public string Header { get; set; }

        public string Description { get; set; }
    }

    public class PositionDictionary
    {
        public string Title { get; set; }
    }
}
