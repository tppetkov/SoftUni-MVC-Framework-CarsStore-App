namespace CarsStore.Models.BindingModels.Offers
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EditOfferBm
    {
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public DateTime OriginDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}