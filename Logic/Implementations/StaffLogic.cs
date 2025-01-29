using GFood.Context;
using GFoodApp.Logic.Interfaces;
using GFoodApp.Models;

namespace GFoodApp.Logic.Implementations
{
    public class StaffLogic : IStaffLogic
    {
      IUserLogic userLogic = new UserLogic();

        public bool Delete(int id)
        {
           foreach (var staff in GFoodAppContext.Staffs)
           {
              if(staff.Id == id)
              {
                GFoodAppContext.Staffs.Remove(staff);
                return true;
              }
           }
           return false;
        }

        public Staff Get(int id)
        {
          foreach (var staff in GFoodAppContext.Staffs)
          {
            if (staff.Id == id)
            {
              return staff;
            }
          }
          return null!;
        }

        public List<Staff> GetAll()
        {
           return GFoodAppContext.Staffs;
        }

        public Staff GetStaffByEmail(string email)
        {
          foreach (var staff in GFoodAppContext.Staffs)
          {
            if(staff.Email == email)
              return staff;
          }
          return null!;
        }

        public Staff Update(string firstName, string lastName, string middleName, string phoneNumber, string address)
        {
          var loginUser = userLogic.GetCurrentUser();
          if (loginUser == null)
          {
            return null!;
          }
          var staff = GetStaffByEmail(loginUser.Email);
          if (staff == null)
          {
            return null!;
          }
          staff.FirstName =firstName;
          staff.LastName =lastName;
          staff.MiddleName = middleName;
          staff.PhoneNumber = phoneNumber;
          staff.Address = address;
          for (int i = 0; i < GFoodAppContext.Staffs.Count; i++)
          {
            if (GFoodAppContext.Staffs[i].Id == staff.Id)
              GFoodAppContext.Staffs[i] = staff;
          }

      return staff;
        }
    }
}