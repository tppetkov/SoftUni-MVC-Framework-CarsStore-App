namespace CarsStore.Service
{
    using CarsStore.Service.Interfaces;

    using Models.EntityModels;

    public class AccountService:Service, IAccountService
    {
        public void CreateUser(ApplicationUser user)
        {
            RegularUser regUser=new RegularUser();
            ApplicationUser currentUser = this.Context.Users.Find(user.Id);
            regUser.User = currentUser;
            this.Context.RegularUsers.Add(regUser);
            this.Context.SaveChanges();
        }
    }
}