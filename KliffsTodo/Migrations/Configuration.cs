namespace KliffsTodo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using KliffsTodo.Models;



    internal sealed class Configuration : DbMigrationsConfiguration<KliffsTodo.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KliffsTodo.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            AddUsers(context);
        }
        void AddUsers(KliffsTodo.Models.ApplicationDbContext context)
        {
            var user = new Models.ApplicationUser { UserName = "user1@gmail.com" };
            var userm = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            userm.Create(user, "password"); 


        }
    }
}
