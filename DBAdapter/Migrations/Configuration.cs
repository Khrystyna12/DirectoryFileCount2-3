using System.Data.Entity.Migrations;

namespace DirectoryFileCount.DBAdapter.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<RequestDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RequestDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
