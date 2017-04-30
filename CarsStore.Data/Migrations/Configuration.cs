namespace CarsStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Models.EntityModels;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<CarsStore.Data.CarsStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CarsStore.Data.CarsStoreContext context)
        {
            if (!context.Roles.Any(role => role.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("User");
                manager.Create(role);
            }
            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");
                manager.Create(role);
            }
            if (!context.Roles.Any(role => role.Name == "BlogAuthor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("BlogAuthor");
                manager.Create(role);
            }

            context.CarsAdvertisements.AddOrUpdate(advert => advert.Brand, new CarOffer[]
                      {
                          new CarOffer()
                                             {
                                                 Brand= "BMW",
                                                 Model = "320",
                                                 Description = "Neveroqtna",
                                                 Price=7500,
                                                 OriginDate = new DateTime(1995,03,23)
                                             },
                          new CarOffer()
                                             {
                                                 Brand= "BMW",
                                                 Model = "330",
                                                 Description = "Begachka",
                                                 Price=10500,
                                                 OriginDate = new DateTime(2010,03,23)
                                             },
                          new CarOffer()
                                             {
                                                 Brand= "BMW",
                                                 Model = "520",
                                                 Description = "Maznaa",
                                                 Price=15500,
                                                 OriginDate = new DateTime(2012,03,23)
                                             },
                          new CarOffer()
                                             {
                                                 Brand= "BMW",
                                                 Model = "760",
                                                 Description = "gyzariq",
                                                 Price=27000,
                                                 OriginDate = new DateTime(2014,03,23)
                                             }
                      });
        }
    }
}
