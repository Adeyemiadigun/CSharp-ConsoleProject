using GFood.Context;
using GFoodApp.Logic.Interfaces;
using GFoodApp.Models;

namespace GFoodApp.Logic.Implementations
{
    public class WalletLogic : IWalletLogic
    {
      IUserLogic userLogic = new UserLogic();
      ICustomerLogic customerLogic = new CustomerLogic();

        public void Delete(int id)
        {
           foreach (var wallet in GFoodAppContext.Wallets)
           {
              if (wallet.Id == id)
                GFoodAppContext.Wallets.Remove(wallet);
           }
        }

        public bool Deposit(decimal amount)
        {
          var user = userLogic.GetCurrentUser();
          var customer = customerLogic.GetCustomerByEmail(user!.Email);
          Wallet wallet = GetWalletById(customer.WalletId);
          if(amount > 0)
          {
            wallet.WalletBalance = amount;
            for (int i = 0; i < GFoodAppContext.Wallets.Count; i++)
            {
              if (GFoodAppContext.Wallets[i].Id == wallet.Id)
                GFoodAppContext.Wallets[i] = wallet;
            }
        return true;
          }
          return false;
        }

        public decimal GetBalance()
        {
          var user = userLogic.GetCurrentUser();
          var customer = customerLogic.GetCustomerByEmail(user!.Email);
          Wallet wallet = GetWalletById(customer.WalletId);
          return wallet.WalletBalance;
        }

        public Wallet GetWalletById(int id)
        {
          foreach (var wallet in GFoodAppContext.Wallets)
          {
            if (wallet.Id == id)
            return wallet;
          }
          return null!;
        }

        public bool MakePayment(decimal amount)
        {
          var user = userLogic.GetCurrentUser();
          var customer = customerLogic.GetCustomerByEmail(user!.Email);
          Wallet wallet = GetWalletById(customer.WalletId);
          if(wallet.WalletBalance >= amount)
          {
            wallet.WalletBalance -= amount;
            for (int i = 0; i < GFoodAppContext.Wallets.Count; i++)
            {
              if (GFoodAppContext.Wallets[i].Id == wallet.Id)
                GFoodAppContext.Wallets[i] = wallet;
            }
        return true;
          }
          return false;
        }
    }
}