namespace CarsStore.Service.Interfaces
{
    using CarsStore.Models.BindingModels.Users;
    using CarsStore.Models.ViewModels.Users;

    public interface IUsersService
    {
        ProfileVm GetProfileVm(string userName);

        EditUserVm GetEditVm(string userName);

        void EditUser(EditUserBm bind, string currentUserName);
    }
}