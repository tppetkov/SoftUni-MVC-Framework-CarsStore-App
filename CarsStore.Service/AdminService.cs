namespace CarsStore.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using CarsStore.Models.BindingModels.Offers;
    using CarsStore.Models.EntityModels;
    using CarsStore.Models.ViewModels.Admin;
    using CarsStore.Models.ViewModels.Adverts;
    using CarsStore.Service.Interfaces;

    public class AdminService : Service, IAdminService
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

        public void DeleteOffer(int id)
        {
            var offer = this.Context.CarsAdvertisements.FirstOrDefault(off => off.Id == id);
            this.Context.CarsAdvertisements.Remove(offer);
            this.Context.SaveChanges();
        }

        public void DeleteUser(string username)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserName == username);

            if (user != null)
            {
                this.Context.Users.Remove(user);
                this.Context.SaveChanges();
            }
        }

        public EditOfferVm GetEditVm(int id)
        {
            var offer = this.Context.CarsAdvertisements.FirstOrDefault(off => off.Id == id);
            EditOfferVm vm = Mapper.Map<CarOffer, EditOfferVm>(offer);

            return vm;
        }

        public void EditOffer(EditOfferBm bind, int id)
        {
            CarOffer offer = this.Context.CarsAdvertisements.FirstOrDefault(off => off.Id == id);
            offer.Brand = bind.Brand;
            offer.Model = bind.Model;
            offer.OriginDate = bind.OriginDate;
            offer.Description = bind.Description;
            offer.Price = bind.Price;
            this.Context.SaveChanges();
        }
    }
}