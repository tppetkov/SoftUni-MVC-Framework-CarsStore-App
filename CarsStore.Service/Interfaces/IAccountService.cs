namespace CarsStore.Service.Interfaces
{
    using CarsStore.Models.EntityModels;

    public interface IAccountService
    {
        void CreateUser(ApplicationUser user);
    }
}