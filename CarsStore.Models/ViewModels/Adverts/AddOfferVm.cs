namespace CarsStore.Models.ViewModels.Adverts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddOfferVm
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

        public byte[] Image { get; set; }
    }
}