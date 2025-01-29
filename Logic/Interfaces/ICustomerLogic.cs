using ConsoleProject.Models.Enums;
using GFoodApp.Models;

namespace GFoodApp.Logic.Interfaces
{
  public interface ICustomerLogic
  {
     bool Create (string firstName, string lastName, string middleName, string email,string password, string phoneNumber, string address,Gender gender);
     Customer GetCustomerByEmail(string email);
     List<Customer> GetAll();
     Customer Update(string firstName, string lastName, string middleName, string phoneNumber, string address);
     bool Delete(int id);
     string GetCustomerName();
  }
}