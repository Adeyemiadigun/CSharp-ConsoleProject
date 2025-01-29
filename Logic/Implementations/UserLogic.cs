using GFood.Context;
using GFoodApp.Logic.Interfaces;

using GFoodApp.Models;

namespace GFoodApp.Logic.Implementations
{
    public class UserLogic : IUserLogic
    {
      private static User? CurrentUser = null;
        public User? GetCurrentUser()
        {
          return CurrentUser;
        }

        public User? Login(string email, string password)
        {
          foreach (User user in GFoodAppContext.Users)
          {
            if (user.Email == email && user.Password == password)
            {
              CurrentUser = user;
              return user;
            }
          }
          return null;

        }

    public bool UserExists(string email)
        {
          foreach (User user in GFoodAppContext.Users)
          {
            if (user.Email == email)
              return true;
          }
          return false;
        }
    }
}