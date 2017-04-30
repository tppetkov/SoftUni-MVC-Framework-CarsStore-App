namespace CarsStore.Models.EntityModels
{
    using System.Collections.Generic;

    public class RegularUser
    {
        public RegularUser()
        {
            this.CarsAdvertisements = new HashSet<CarOffer>();
        }
        public int Id { get; set; } 

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<CarOffer> CarsAdvertisements { get; set; }
    }
}