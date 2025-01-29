using ConsoleProject.Models.Enums;

namespace GFoodApp.Models
{
  public class Staff
  {
    public int Id { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string Email { get; set; } = default!;
   public Gender Gender { get; set; } = default; 
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;

    public Staff(int id,string firstName, string lastName,string middleName, string email, string phoneNumber,string address ,Gender gender )
    {
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      MiddleName = middleName;
      Email = email;
      PhoneNumber = phoneNumber;
      Address = address;
      Gender = gender;
    }
  }
}