using ConsoleProject.Models.Enums;

namespace GFoodApp.Models
{
  public class Customer
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public int WalletId { get; set; }
    public Gender Gender { get; set; }
    public Order order { get; set; }
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;

    public Customer(int id, string firstName, string lastName, string middleName, string email, string phoneNumber, string address,int walletId,Gender gender)
    {
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      MiddleName = middleName;
      Email = email;
      PhoneNumber = phoneNumber;
      Address = address;
      WalletId = walletId;
      Gender = gender;
    }
  }
}