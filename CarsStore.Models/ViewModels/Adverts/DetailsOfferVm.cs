namespace CarsStore.Models.ViewModels.Adverts
{
    using System;

    using CarsStore.Models.EntityModels;

    public class DetailsOfferVm
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public DateTime OriginDate { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public byte[] Image { get; set; }

        public virtual ApplicationUser Seller { get; set; }
    }
}