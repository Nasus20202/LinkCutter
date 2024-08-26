using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LinkCutter
{
    public class Database : DbContext
    {

        public DbSet<Link> Links { get; set; }
        public string DbPath { get; set; }

        public Database()
        {
            var localPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data");
            if (!Directory.Exists(localPath))
            {
                Directory.CreateDirectory(localPath);
            }
            DbPath = Path.Join(localPath, "links.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
