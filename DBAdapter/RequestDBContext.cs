using System.Data.Entity;
using DirectoryFileCount.DBAdapter.Migrations;
using DirectoryFileCount.DBModels;

namespace DirectoryFileCount.DBAdapter
{
    internal class RequestDBContext : DbContext
    {
        public RequestDBContext():base("NewRequestDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RequestDBContext, Configuration>(true));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new User.UserEntityConfiguration());
            modelBuilder.Configurations.Add(new Request.RequestEntityConfiguration());
        }
    }
}
