using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelstarLogistcs.DbClient.Entitites;

namespace TelstarLogistics.DbClient.Setup
{
    public class DataContext : DbContext
    {
        protected readonly IOptions<DbSettings> _dbOptions;

        public DataContext(IOptions<DbSettings> dbOptions)
        {
            _dbOptions = dbOptions;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(_dbOptions.Value.ConnectionString);
        }

        public DbSet<UserRole> UserRole { get; set; }
    }
}
