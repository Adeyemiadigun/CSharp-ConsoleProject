using ConsoleProject.Models.Enums;
using GFoodApp.Models;

namespace GFoodApp.Logic.Interfaces
{
   public interface IDeliveryManLogic
  {
   bool Create(string firstName, string lastName, string middleName, string email, string password, string phoneNumber, string address, string plateNumber,Gender gender);
   bool Delete(int id);
   DeliveryMan Get(int id);
   bool Update(string email,string firstName, string lastName, string middleName, string phoneNumber, string address);
   DeliveryMan GetAvailableDeliveryMan();
   void SetAvailability(int id);
   DeliveryMan GetDeliveryManByStaffId(int staffId);
   string GetDeliveryManName();
   Order CheckAssigedOrder();
   DeliveryMan GetDeliveryManByEmail(string email);
   List<DeliveryMan> GetAll();
  }
}