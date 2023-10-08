using Domain.ParkingFloor;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Persistence
{
    public partial class DatabaseContext : DbContext
    {
        private readonly string _connectionString;
        public DatabaseContext() : this(ConfigurationManager.ConnectionStrings["ParkingEntities"].ConnectionString)
        {
        }
        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DatabaseContext(DbContextOptions options, string connectionString) : base(options)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public virtual DbSet<ParkingFloor> ParkingFloors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(this._connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ParkingFloorConfiguration());
        }
    }
}
