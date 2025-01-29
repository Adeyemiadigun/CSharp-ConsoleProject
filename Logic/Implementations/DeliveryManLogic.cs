using GFoodApp.Logic.Interfaces;
using GFoodApp.Models;
using GFood.Context;
using ConsoleProject.Models.Enums;

namespace GFoodApp.Logic.Implementations
{
    public class DeliveryManLogic : IDeliveryManLogic
    {
      IStaffLogic staffLogic = new StaffLogic();
      IUserLogic userLogic = new UserLogic();
        public bool Create(string firstName, string lastName, string middleName, string email, string password, string phoneNumber, string address,string plateNumber,Gender gender)
        {
          var userExist = userLogic.UserExists(email);
          if (userExist)
          {
            return false;
          }
          var user = new User(GFoodAppContext.Users.Count + 1, email, password, "GF_DeliveryMan");
          GFoodAppContext.Users.Add(user);
          var staff = new Staff(GFoodAppContext.Staffs.Count + 1, firstName, lastName, middleName, email, phoneNumber, address,gender);
          GFoodAppContext.Staffs.Add(staff);
          var deliveryMan = new DeliveryMan(GFoodAppContext.Staffs.Count + 1, staff.Id, plateNumber);
          GFoodAppContext.DeliveryGuys.Add(deliveryMan);
          return true;
        }

        public bool Delete(int id)
        {
          foreach (var deliveryMan in GFoodAppContext.DeliveryGuys)
          {
            if (deliveryMan.Id == id)
            {
              staffLogic.Delete(deliveryMan.StaffId);
              GFoodAppContext.DeliveryGuys.Remove(deliveryMan);
              return true;
            }
          }
          return false;
        }

        public DeliveryMan Get(int id)
        {
          foreach (var deliveryMan in GFoodAppContext.DeliveryGuys)
          {
            if(deliveryMan.Id == id)
              return deliveryMan;
          }
          return null!;
        }

        public DeliveryMan GetAvailableDeliveryMan()
        {
          foreach (var deliveryMan in GFoodAppContext.DeliveryGuys)
          {
            if(deliveryMan.IsAvailable)
              return deliveryMan;
          }
          return null!;
        }

        public string GetDeliveryManName()
        {
          var user = userLogic.GetCurrentUser();
          var deliveryMan = staffLogic.GetStaffByEmail(user!.Email);
          return deliveryMan.FirstName;
        }

        public DeliveryMan GetDeliveryManByStaffId(int staffId)
        {
           foreach (var deliveryMan in GFoodAppContext.DeliveryGuys)
           {
              if(deliveryMan.StaffId == staffId)
              return deliveryMan;
           }
           return null!;
        }


        public void SetAvailability(int id)
        {
          foreach (var deliveryMan in GFoodAppContext.DeliveryGuys)
          {
            if(deliveryMan.Id == id)
            {
              deliveryMan.IsAvailable = true;
              for (int i = 0; i < GFoodAppContext.DeliveryGuys.Count; i++)
              {
                if (GFoodAppContext.DeliveryGuys[i].Id == deliveryMan.Id)
                  GFoodAppContext.DeliveryGuys[i] = deliveryMan;
              }
            }
          }
        }
        public Order CheckAssigedOrder()
        {
          var user = userLogic.GetCurrentUser();
          var deliveryMan = GetDeliveryManByEmail(user!.Email);
          foreach (var order in GFoodAppContext.ActiveOrders)
          {
            if(order.DeliveryGuyId == deliveryMan.Id)
              return order;
          }
          return null!;
        }


        public DeliveryMan GetDeliveryManByEmail(string email)
        {
          var staff = staffLogic.GetStaffByEmail(email);
          foreach (var deliveryMan in GFoodAppContext.DeliveryGuys)
          {
            if(staff.Id == deliveryMan.StaffId)
              return deliveryMan;
          }
          return null!;
        }

        public bool Update(string email, string firstName, string lastName, string middleName, string phoneNumber, string address)
        {
          var deliveryMan = staffLogic.GetStaffByEmail(email);
          deliveryMan.FirstName = firstName;
          deliveryMan.LastName = lastName;
          deliveryMan.MiddleName = middleName;
          deliveryMan.PhoneNumber = phoneNumber;
          deliveryMan.Address = address;
          for (int i = 0; i < GFoodAppContext.Staffs.Count; i++)
          {
            if (GFoodAppContext.Staffs[i].Id == deliveryMan.Id)
              GFoodAppContext.Staffs[i] = deliveryMan;
          }
          return true;
        }

        public List<DeliveryMan> GetAll()
        {
          return GFoodAppContext.DeliveryGuys;
        }
    }
}
