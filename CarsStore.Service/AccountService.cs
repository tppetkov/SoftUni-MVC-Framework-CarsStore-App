namespace CarsStore.Service
{
    using Models.EntityModels;

    public class AccountService:Service
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