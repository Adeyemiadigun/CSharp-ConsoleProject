using GFoodApp.Logic.Interfaces;
using GFoodApp.Logic.Implementations;
using ConsoleProject.Models.Enums;

namespace GFoodApp.Menu
{
  public partial class MainMenu
  {
    IDeliveryManLogic deliveryManLogic = new DeliveryManLogic();
    ICategoryLogic categoryLogic = new CategoryLogic();
    IFoodLogic foodLogic = new FoodLogic();
    IStaffLogic staffLogic = new StaffLogic();
    IOrderLogic orderLogic = new OrderLogic();
    IUserLogic userLogic = new UserLogic();
    ICustomerLogic customerLogic = new CustomerLogic();
    IWalletLogic walletLogic = new WalletLogic();
    IReviewLogic reviewLogic = new ReviewLogic();
    public void Start()
    {
      Console.WriteLine("Welcome to GFood App\n1. Register\n2. Login\n3. Exit ");
      int choice = Convert.ToInt32(Console.ReadLine());
      switch (choice)
      {
        case 1:
          RegisterMenu();
          Start();
          break;
        case 2:
          LoginMenu();
          break;
        case 3:
          Console.WriteLine("Goodbye!");
          break;
        default:
          Console.WriteLine("Invalid choice. Please try again.");
          Start();
          break;
      }
    }
    private void RegisterMenu()
    {
      Console.Write("Email: ");
      string email = Console.ReadLine()!;
      Console.Write("Password: ");
      string password = Console.ReadLine()!;
      Console.Write("First Name: ");
      string fName = Console.ReadLine()!;
      Console.Write("Last Name: ");
      string lName = Console.ReadLine()!;
      Console.Write("Middle Name: ");
      string middleName = Console.ReadLine()!;
      Console.Write("Address: ");
      string address = Console.ReadLine()!;
      Console.Write("Phone Number: ");
      string phone = Console.ReadLine()!;
      Console.Write("Gender:\n1. Male\n2. Female ");
      int gender =int.Parse( Console.ReadLine()!);
      Gender genders = gender == 1? Gender.Male : Gender.Female;

      var response = customerLogic.Create(fName,lName,middleName,email,password,phone,address, genders);
      if (!response)
      {
        Console.WriteLine($"{email} already exist");
      }
      else
      {
        Console.WriteLine("registration succesful");
      }
    }
    private void LoginMenu()
    {
      Console.Write("Email: ");
      string email = Console.ReadLine()!;
      Console.Write("Password: ");
      string password = Console.ReadLine()!;

      var response = userLogic.Login(email, password);
      if (response == null)
      {
        Console.WriteLine("invalid cridentials");
        LoginMenu();
      }
      else
      {
        if (response.Role == "GF_SuperAdmin")
        {
          SuperManinMenu();
        }
        else if (response.Role == "GF_Customer")
        {
          CustomerMainMenu();
        }
        else if(response.Role == "GF_DeliveryMan")
        {
          DeliveryManMainMenu();
        }
      }
    }
  }
}