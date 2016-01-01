namespace ATM.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class AtmDbContext : DbContext
    {
        public AtmDbContext()
            : base("AtmDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmDbContext, Configuration>());
        }

        public IDbSet<CardAccount> CardAccounts { get; set; }

        public IDbSet<TransactionHistory> TransactionHistories { get; set; }
    }
}