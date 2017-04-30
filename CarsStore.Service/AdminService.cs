namespace CarsStore.Service
{
    using System.Collections.Generic;

    using AutoMapper;

    using CarsStore.Models.EntityModels;
    using CarsStore.Models.ViewModels.Admin;
    using CarsStore.Models.ViewModels.Adverts;

    public class AdminService : Service
    {
        public AdminPageVm GetAdminPage()
        {
            AdminPageVm page = new AdminPageVm();
            IEnumerable<CarOffer> offers = this.Context.CarsAdvertisements;
            IEnumerable<RegularUser> users = this.Context.RegularUsers;

            IEnumerable<OfferVm> offerVms = Mapper.Map<IEnumerable<CarOffer>, IEnumerable<OfferVm>>(offers);
            IEnumerable<AdminUserVm> userVms = Mapper.Map<IEnumerable<RegularUser>, IEnumerable<AdminUserVm>>(users);

            page.Users = userVms;
            page.Offers = offerVms;

            return page;
        }
    }
}