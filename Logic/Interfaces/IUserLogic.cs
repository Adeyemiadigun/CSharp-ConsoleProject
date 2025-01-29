using GFoodApp.Models;
namespace GFoodApp.Logic.Interfaces
{
  public interface IUserLogic
  {
     User? Login (string email, string password);
     User? GetCurrentUser();
     bool UserExists (string email);

  }
}