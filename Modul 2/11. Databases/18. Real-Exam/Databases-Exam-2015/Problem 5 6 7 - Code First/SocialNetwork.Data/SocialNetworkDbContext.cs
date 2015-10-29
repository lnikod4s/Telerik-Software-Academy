namespace SocialNetwork.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Migrations;

    using Models;

    public class SocialNetworkDbContext : DbContext
    {
        public SocialNetworkDbContext()
            : base("SocialNetwork")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Posts).WithMany(p => p.Users).Map(
                pu =>
                    {
                        pu.MapLeftKey("UserRefId");
                        pu.MapRightKey("PostRefId");
                        pu.ToTable("UsersPosts");
                    });

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}