using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
namespace HouseCalcApi.Models
{
    public class AppContext : DbContext
    {
        private readonly string _dataSource;
        public DbSet<Price> Prices { get; set; }
        public DbSet<UserCalculationRequest> UserCalculationRequests { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }

        public DbSet<ClientRequestId> ClientRequestIds {  get; set; }

        public AppContext(string dataSource = "Data Source=houseapp.db")
        {
            _dataSource = dataSource;
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnection(_dataSource);
            connectionStringBuilder.Open();
            optionsBuilder.UseSqlite(connectionStringBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Price>().HasData(
                    new Price { Id = 1, Name = "setwalls", Value = 16000 },
                    new Price { Id = 2, Name = "project", Value = 650 },
                    new Price { Id = 3, Name = "geologi", Value = 40000 },
                    new Price { Id = 4, Name = "geodesy", Value = 15000 },
                    new Price { Id = 5, Name = "construction", Value = 5500 },
                    new Price { Id = 6, Name = "armo", Value = 300 },
                    new Price { Id = 7, Name = "seams", Value = 300 },
                    new Price { Id = 8, Name = "delivery", Value = 200 },
                    new Price { Id = 9, Name = "fundation", Value = 11500 },
                    new Price { Id = 10, Name = "roof", Value = 13500 },
                    new Price { Id = 11, Name = "windows", Value = 15500 },
                    new Price { Id = 12, Name = "door", Value = 65000 }
            );
        }
    }
}
