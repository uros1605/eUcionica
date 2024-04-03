using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBContext;

namespace DBContext
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<DBContextClass>
    {
        public DBContextClass CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContextClass>();
            string databasePath = Path.Combine("..", "eUcionicaDatabase.db");
            optionsBuilder.UseSqlite($"Data Source={databasePath}");

            return new DBContextClass(optionsBuilder.Options);
        }
    }
}
