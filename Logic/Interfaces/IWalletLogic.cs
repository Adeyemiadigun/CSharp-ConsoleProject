

using GFoodApp.Models;

namespace GFoodApp.Logic.Interfaces
{
  public interface IWalletLogic
  {
     bool Deposit(decimal amount);
     Wallet GetWalletById(int id);
     decimal GetBalance();
     void Delete(int id);
     bool MakePayment(decimal amount);
  }
}