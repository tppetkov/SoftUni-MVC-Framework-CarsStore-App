namespace CarsStore.Data
{
    using System.Data.Entity;

    using Models.EntityModels;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class CarsStoreContext : IdentityDbContext<ApplicationUser>
    {

        public CarsStoreContext()
            : base("data source=MRT-PC\\SQLEXPRESS2;initial catalog=CarsStore.Data.CarsStoreContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<CarOffer> CarsAdvertisements { get; set; }

        public DbSet<RegularUser> RegularUsers { get; set; }
        public static CarsStoreContext Create()
        {
            return new CarsStoreContext();
        }
    }
}