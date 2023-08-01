using NeilvynSampleBlueprint.Mobile.Domain.Persistance;
using NeilvynSampleBlueprint.Mobile.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Services.Persistance
{
    public class MobileDbContext : DbContext
    {
        private readonly IDatabaseFactory _databaseFactory;

        public DbSet<User> Users { get; set; }

        public MobileDbContext(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;

            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databasePath = _databaseFactory.GetDatabasePath(Mobile.Common.Constants.Database.DatabaseName);
            var connection = new SqliteConnectionStringBuilder
            {
                DataSource = databasePath,
                Mode = SqliteOpenMode.ReadWriteCreate,
                // Password = Common.Constants.Database.CipherPassword
            };

            optionsBuilder.UseSqlite(connection.ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
