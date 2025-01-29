namespace GFoodApp.Models
{
  public class Wallet
  {
    public int Id { get; set; }
    public decimal WalletBalance { get; set; } = default;

    public Wallet(int id)
    {
      Id = id;
    }
  }
}