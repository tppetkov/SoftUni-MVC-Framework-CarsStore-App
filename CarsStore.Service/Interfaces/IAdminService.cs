namespace CarsStore.Service.Interfaces
{
    using CarsStore.Models.BindingModels.Offers;
    using CarsStore.Models.ViewModels.Admin;
    using CarsStore.Models.ViewModels.Adverts;

    public interface IAdminService
    {
        AdminPageVm GetAdminPage();

        void DeleteOffer(int id);

        void DeleteUser(string username);

        EditOfferVm GetEditVm(int id);

        void EditOffer(EditOfferBm bind, int id);
    }
}