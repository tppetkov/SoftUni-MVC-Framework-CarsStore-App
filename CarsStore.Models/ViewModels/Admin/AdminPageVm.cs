namespace CarsStore.Models.ViewModels.Admin
{
    using System.Collections.Generic;

    using CarsStore.Models.EntityModels;
    using CarsStore.Models.ViewModels.Adverts;

    public class AdminPageVm
    {
        public IEnumerable<OfferVm> Offers { get; set; }

        public IEnumerable<AdminUserVm> Users { get; set; }

    }
}