using Microsoft.EntityFrameworkCore;
using SqlitePerformanceTests.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlitePerformanceTests.Data
{
    class ApplicationDbContext: DbContext
    {
        public DbSet<Lichtpunkt> Lichtpunkt { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bla.db");
        }
    }
}
