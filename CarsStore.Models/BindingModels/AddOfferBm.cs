namespace CarsStore.Models.BindingModels
{
    using System;

    public class AddOfferBm
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public DateTime OriginDate { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}