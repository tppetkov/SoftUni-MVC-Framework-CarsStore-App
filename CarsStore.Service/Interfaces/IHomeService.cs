namespace CarsStore.Service.Interfaces
{
    using System.Collections.Generic;

    using CarsStore.Models.ViewModels.Adverts;

    public interface IHomeService
    {
        IEnumerable<OfferVm> GetAllAdverts();
    }
}