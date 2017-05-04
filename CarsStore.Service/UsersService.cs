namespace CarsStore.Service
{
    using System.Linq;

    using AutoMapper;

    using CarsStore.Service.Interfaces;

    using Models.BindingModels.Users;
    using Models.EntityModels;
    using Models.ViewModels.Users;

    public class UsersService:Service, IUsersService
    {
        
        public ProfileVm GetProfileVm(string userName)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(user => user.UserName == userName);
            ProfileVm vm = Mapper.Map<ApplicationUser, ProfileVm>(currentUser);

            return vm;
        }

        public EditUserVm GetEditVm(string userName)
        {
            ApplicationUser user =
                this.Context.Users.FirstOrDefault(applicationUser => applicationUser.UserName == userName);
            EditUserVm vm = Mapper.Map<ApplicationUser, EditUserVm>(user);

            return vm;
        }

        public void EditUser(EditUserBm bind, string currentUserName)
        {
            ApplicationUser user =
               this.Context.Users.FirstOrDefault(applicationUser => applicationUser.UserName == currentUserName);
            user.Name = bind.Name;
            user.Email = bind.Email;
            this.Context.SaveChanges();
        }
    }
}