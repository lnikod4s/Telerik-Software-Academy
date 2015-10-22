namespace Cars.Data
{
    using System.Data.Entity;

    using Migrations;

    using Models;

    public class CarsDbContext : DbContext
    {
        public CarsDbContext()
            : base("Cars")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
        }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Dealer> Dealers { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}