using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
namespace HauseCalcApi.Models
{
    public class AppContext : DbContext
    {
        private readonly string _dataSource;
        public DbSet<Price> Prices { get; set; }
        public DbSet<SetServiceClient> SetServiceClients { get; set; }

        public AppContext(string dataSource = "Data Source=helloapp.db")
        {
            _dataSource = dataSource;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnection(_dataSource);
            connectionStringBuilder.Open();
            optionsBuilder.UseSqlite(connectionStringBuilder);
        }
    }
}
