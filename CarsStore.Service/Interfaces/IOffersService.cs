namespace CarsStore.Service.Interfaces
{
    using System.Web;

    using CarsStore.Models.BindingModels;
    using CarsStore.Models.EntityModels;
    using CarsStore.Models.ViewModels.Adverts;

    public interface IOffersService
    {
        DetailsOfferVm GetDetails(int id);

        void AddNewOffer(AddOfferBm bind, HttpPostedFileBase file, string username);

        byte[] GetImageFromBind(HttpPostedFileBase bindImage);

        CarOffer GetAttractionImage(int id);
    }
}