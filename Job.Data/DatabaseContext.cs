using Job.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Job.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Vacancy> Vacancies { get; set; }

        public DbSet<Rubric> Rubrics { get; set; }

        public DbSet<VersionInfo> VersionInfos { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options) { }
    }
}
