using System;
using System.Collections.Generic;
using System.Text;

namespace Job.Data.Models
{
    public class VersionInfo
    {
        public Guid VersionInfoId { get; set; }

        public DateTime UpdateAt { get; set; }

        public DataType DataType { get; set; }

        public int Count { get; set; }

        public int CountDownloded { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsDownloaded { get; set; }

        public bool IsRemoved { get; set; }
    }

    public enum DataType
    {
        Vacancy = 0,
        Rubric
    }
}
