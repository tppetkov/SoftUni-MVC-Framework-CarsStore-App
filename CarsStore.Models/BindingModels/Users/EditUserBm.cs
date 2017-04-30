namespace CarsStore.Models.BindingModels.Users
{
    using System.ComponentModel.DataAnnotations;

    public class EditUserBm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}