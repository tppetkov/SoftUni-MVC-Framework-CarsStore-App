namespace CarsStore.Models.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;

    public class EditUserVm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}