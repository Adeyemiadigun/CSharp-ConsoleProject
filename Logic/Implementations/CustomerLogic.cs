using ConsoleProject.Models.Enums;
using GFood.Context;
using GFoodApp.Logic.Interfaces;
using GFoodApp.Models;

namespace GFoodApp.Logic.Implementations
{
    public class CustomerLogic : ICustomerLogic
    {
        IUserLogic userLogic = new UserLogic();
        public bool Create(string firstName, string lastName,string middleName, string email, string password, string phoneNumber, string address,Gender gender)
        {
          var user = userLogic.UserExists(email);
          if (user)
          {
            return false;
          }
          User newUser = new User(GFoodAppContext.Foods.Count+1,email,password,"GF_Customer");
          GFoodAppContext.Users.Add(newUser);
          Wallet newWallet = new Wallet(GFoodAppContext.Wallets.Count + 1);
          GFoodAppContext.Wallets.Add(newWallet);
          Customer customer = new Customer(GFoodAppContext.Customers.Count+1,firstName,lastName,middleName,email,phoneNumber,address, newWallet.Id,gender);
          GFoodAppContext.Customers.Add(customer);
          return true;
        }

        public bool Delete(int id)
        {
          foreach (var customer in GFoodAppContext.Customers)
          {
            if (customer.Id == id)
            {
              GFoodAppContext.Customers.Remove(customer);
              return true;
            }
          }
          return false;
        }

        public List<Customer> GetAll()
        {
          return GFoodAppContext.Customers;
        }

        public Customer GetCustomerByEmail(string email)
        {
          foreach (var customer in GFoodAppContext.Customers)
          {
            if(customer.Email == email)
              return customer;
          }
          return null!;
        }

        public string GetCustomerName()
        {
          var user = userLogic.GetCurrentUser();
          var customer = GetCustomerByEmail(user!.Email);
          return customer.FirstName;
        }

        public Customer Update(string firstName, string lastName, string middleName, string phoneNumber, string address)
        {
          var user = userLogic.GetCurrentUser();
          var customer = GetCustomerByEmail(user!.Email);
          customer.FirstName = firstName;
          customer.LastName = lastName;
          customer.MiddleName = middleName;
          customer.PhoneNumber = phoneNumber;
          customer.Address = address;
          for (int i = 0; i < GFoodAppContext.Customers.Count; i++)
          {
            if (GFoodAppContext.Customers[i].Id == customer.Id)
              GFoodAppContext.Customers[i] = customer;
          }
          return customer;
        }
    }
}