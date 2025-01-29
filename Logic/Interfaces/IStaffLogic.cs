using GFoodApp.Models;

namespace GFoodApp.Logic.Interfaces
{
  public interface IStaffLogic
  {

     Staff Get(int id);
     List<Staff> GetAll();
     Staff GetStaffByEmail(string email);
     Staff Update(string firstName, string lastName, string middleName, string phoneNumber, string address);
     bool Delete(int id);
  }
}