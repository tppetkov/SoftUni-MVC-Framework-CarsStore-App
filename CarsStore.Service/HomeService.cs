namespace CarsStore.Service
{
    using System.Collections.Generic;

    using AutoMapper;

    using CarsStore.Service.Interfaces;

    using Models.EntityModels;
    using Models.ViewModels.Adverts;

    public class HomeService:Service, IHomeService
    {
        public IEnumerable<OfferVm> GetAllAdverts()
        {
            IEnumerable<CarOffer> adverts = this.Context.CarsAdvertisements;
            IEnumerable<OfferVm> vms=Mapper.Map<IEnumerable<CarOffer>,IEnumerable<OfferVm>>(adverts);

            return vms;
        }
    }
}