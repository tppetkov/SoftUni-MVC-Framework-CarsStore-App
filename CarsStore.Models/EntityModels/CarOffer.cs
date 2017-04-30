namespace CarsStore.Models.EntityModels
{
    using System;
    using System.Collections;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CarOffer
    {
        public int Id { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }

        public DateTime OriginDate { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public virtual ApplicationUser Seller { get; set; }
    }
}