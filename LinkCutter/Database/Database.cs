using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LinkCutter
{
    public class Database : DbContext
    {
        public static string ConnectionString = "";

        public DbSet<Link> Links { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVerison = new MySqlServerVersion(new Version(8, 0, 21));
            optionsBuilder.UseMySql(ConnectionString, serverVerison).EnableSensitiveDataLogging().EnableDetailedErrors();
        }
    }
}
