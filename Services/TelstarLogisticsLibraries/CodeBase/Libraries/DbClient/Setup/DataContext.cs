using DbClient.Entitites;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingRouteRef>().HasKey(x => new { x.BookingID, x.RouteID });
        }

        public DbSet<Booking> Booking { get; set; }
        public DbSet<BookingRouteRef> BookingRouteRef { get; set; }
        public DbSet<BookingStatus> BookingStatus { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<PackageContentType> PackageContentType { get; set; }
        public DbSet<PackageSizeType> PackageSizeType { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<SegmentPrice> SegmentPrice { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}