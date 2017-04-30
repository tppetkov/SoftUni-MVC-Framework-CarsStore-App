namespace CarsStore.Models.ViewModels.Adverts
{
    public class OfferVm
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }

        public byte[] Image { get; set; }
    }
}