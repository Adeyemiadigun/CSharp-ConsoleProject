
using ConsoleProject.Models.Enums;


namespace GFoodApp.Menu
{
  public partial class MainMenu
  {
    public  void SuperManinMenu()
    {
      
      Console.WriteLine("Welcome Admin");
      Console.WriteLine("Please choose an option: \n1. Register Delivery Man \n2. Create Food Category \n3. Add Food \n4. Views \n5. Delete \n6. Log Out");
      int choice = Convert.ToInt32(Console.ReadLine());
      switch (choice)
      {
        case 1:
          Console.Clear();
          RegisterDeliveryGuy();
          SuperManinMenu();
          break;
        case 2:
          Console.Clear();
          CreateCategory();
          SuperManinMenu();
          break;
        case 3:
          Console.Clear();
          AddFood();
          SuperManinMenu();
          break;
        case 4:
          Console.Clear();
          GetInformation();
          break;
        case 5:
          Console.Clear();
          Delete();
          break;
        case 6:
          Console.Clear();
          Start();
          break;
        default:
          Console.WriteLine("Invalid choice. Please try again.");
          SuperManinMenu();
          break;
      }
    }
    private void RegisterDeliveryGuy()
    {
      Console.Write("First Name: ");
      string firstName = Console.ReadLine()!;
      Console.Write("Last Name: ");
      string lastName = Console.ReadLine()!;
      Console.Write("Middle Name: ");
      string middleName = Console.ReadLine()!;
      Console.Write("Email: ");
      string email = Console.ReadLine()!;
      Console.Write("Password: ");
      string password = Console.ReadLine()!;
      Console.Write("Address: ");
      string address = Console.ReadLine()!;
      Console.Write("Phone Number: ");
      string phoneNumber = Console.ReadLine()!;
      Console.Write("Gender:\n1. Male\n2. Female ");
      int gender = int.Parse(Console.ReadLine()!);
      Gender genders = gender == 1 ? Gender.Male : Gender.Female;
      var response = deliveryManLogic.Create(firstName, lastName, middleName, email, password, phoneNumber,address, phoneNumber,genders);
      if (!response)
      {
        Console.WriteLine($"{email} already exist");
      }
      else
      {
        Console.WriteLine("Registration successful");
      }
    }
    private void CreateCategory()
    {
      Console.Write("Category Name: ");
      string categoryName = Console.ReadLine()!;
      Console.Write("Enter Description: ");
      string description = Console.ReadLine()!;
      var response = categoryLogic.Create(categoryName, description);
      if (!response)
      {
        Console.WriteLine($"Category {categoryName} already exist");
      }
      else
      {
        Console.WriteLine($"Category {categoryName} created successfully");
      }
    }
    private void AddFood()
    {
      foreach (var category in categoryLogic.GetAll())
      {
        Console.WriteLine($"{category.Id} {category.Name} {category.Description}");
      }
      Console.Write("Enter category ID: ");
      int categoryId = Convert.ToInt32(Console.ReadLine());
      Console.Write("Food Name: ");
      string foodName = Console.ReadLine()!;
      Console.Write("Description: ");
      string foodDescription = Console.ReadLine()!;
      Console.Write("Unit Price: ");
      decimal unitPrice = Convert.ToDecimal(Console.ReadLine());
      var response = foodLogic.Create(foodName, foodDescription, categoryId, unitPrice);
      Console.WriteLine("Adding food...");
      if (response)
      {
        Console.WriteLine($"Food {foodName} added successfully");
      }
      else
      {
        Console.WriteLine($"Food {foodName} already exist");
      }
      
    }
    private void Delete()
    {
      Console.WriteLine("1.Delete Food \n2.Delete Category \n3. Delete Delivery Man Account \n4. Exit");
      int choice = int.Parse(Console.ReadLine()!);
      switch (choice)
      {
        case 1:
          Console.Clear();
          DeleteFood();
          Delete();
          break;
        case 2:
          Console.Clear();
          DeleteCategory();
          Delete();
          break;
        case 3:
          Console.Clear();
          DeleteDeliveryMan();
          Delete();
          break;
        case 4:
          Console.Clear();
          SuperManinMenu();
          break;
        default:
          Console.WriteLine("Invalid choice. Please try again.");
          Delete();
          break;
      }

    }
    private void DeleteFood()
    {
      foreach (var item in foodLogic.GetAllFoods())
      {
        Console.WriteLine($"{item.Id} Food name: {item.Name}   Food Description: {item.Description}");
      }
      Console.WriteLine("Select the food to delete: ");
      int res = int.Parse(Console.ReadLine()!);
      var response = foodLogic.Delete(res);
      if (response)
      {
        Console.WriteLine("Food deleted successfully");
      }
      else
      {
        Console.WriteLine("Food not found");
      }
    }
    private void DeleteCategory()
    {
      Console.WriteLine("All foods that belongs to the deleted vategory will also be deleted");
      foreach (var item in categoryLogic.GetAll())
      {
        Console.WriteLine($"{item.Id} Category Name: {item.Name}  Category Description: {item.Description}");
      }
      Console.WriteLine("Select the category to delete: ");
      int res = int.Parse(Console.ReadLine()!);
      var response = categoryLogic.Delete(res);
      if (response)
      {
        foodLogic.DeleteByCategoryId(res);
        Console.WriteLine("Category deleted successfully");
      }
      else
      {
        Console.WriteLine("Category not found");
      }
    }
    private void DeleteDeliveryMan()
    {
      foreach (var deliveryMan in deliveryManLogic.GetAll())
      {
        foreach (var staffs in staffLogic.GetAll())
        {
          if(deliveryMan.StaffId == staffs.Id)
            Console.WriteLine($"{deliveryMan.Id}. {staffs.FirstName} {staffs.LastName} {staffs.Email} {staffs.Address} {staffs.PhoneNumber} {deliveryMan.PlateNumber}");
        }
      }
      Console.WriteLine("Select the delivery man to delete: ");
      int res = int.Parse(Console.ReadLine()!);
      var dMan = deliveryManLogic.Get(res);
      var staff = staffLogic.Get(dMan.StaffId);
      var response = deliveryManLogic.Delete(res);
      if (response)
      {
        staffLogic.Delete(staff.Id);
        Console.WriteLine("Delivery man and staff deleted successfully");
      }
    }
  

      
    private void GetInformation()
    {
      Console.WriteLine("1. View All Staff \n2. View All Food Categories \n3. View Available Foods \n4. View All Orders \n5.All Active Order \n6. View All Completed Order \n7. View All Canceled Order\n8. View All Customer\n9. View Staff By Id \n10. View Staff By Email \n11. View Food By Id \n12. View Food By Name \n13. View Category By Id \n14. View Category By Name \n15. View all Review \n16. Exit ");
      int choice = Convert.ToInt32(Console.ReadLine());
      switch (choice)
      {
        case 1:
          Console.Clear();
          ViewAllStaff();
          GetInformation();
          break;
        case 2:
          Console.Clear();
          ViewAllCategories();
          GetInformation();
          break;
        case 3:
          Console.Clear();
          ViewAllFood();
          GetInformation();
          break;
        case 4:
          Console.Clear();
          ViewAllOrder();
          GetInformation();
          break;
        case 5:
          Console.Clear();
          ViewAllActiveOrder();
          GetInformation();
          break;
        case 6:
          Console.Clear();
          ViewAllCompletedOrders();
          GetInformation();
          break;
        case 7:
          Console.Clear();
          ViewAllCancelledOrder();
          GetInformation();
          break;
        case 8:
          Console.Clear();
          ViewAllCustomer();
          GetInformation();
          break;
        case 9:
          Console.Clear();
          ViewStaffById();
          GetInformation();
          break;
        case 10:
          Console.Clear();
          ViewStaffByEmail();
          GetInformation();
          break;
        case 11:
          Console.Clear();
          ViewFoodById();
          GetInformation();
          break;
        case 12:
          Console.Clear();
          ViewFoodByName();
          GetInformation();
          break;
        case 13:
          Console.Clear();
          ViewCategoryById();
          GetInformation();
          break;
        case 14:
          Console.Clear();
          ViewCategoryByName();
          GetInformation();
          break;
        case 15:
          Console.Clear();
          ViewAllReviews();
          SuperManinMenu();
          break;
        case 16:
          Console.Clear();
          SuperManinMenu();
          break;
        default:
          Console.WriteLine("Invalid choice. Please try again.");
          GetInformation();
          break;
      }
    }
    private void ViewAllFood()
    {
      foreach (var food in foodLogic.GetAllFoods())
      {
        Console.WriteLine($"{food.Id}. Food Name: {food.Name}  Food Description: {food.Description} Category Id: {food.CategoryId} Unit Price: {food.UnitPrice}");
      }
    }
    private void ViewAllStaff()
    {
      foreach (var staff in staffLogic.GetAll())
      {
        Console.WriteLine($"{staff.Id} {staff.FirstName} {staff.LastName}  {staff.MiddleName} {staff.Email} {staff.PhoneNumber} {staff.Address} {staff.Gender}");
      }
    }
    private void ViewAllCategories()
    {
      foreach (var category in categoryLogic.GetAll())
      {
        Console.WriteLine($"{category.Id} Category Name{category.Name}  description: {category.Description}");
      }
    }
    private void ViewAllOrder()
    {
      foreach (var order in orderLogic.GetAll())
      {
        Console.WriteLine($"{order.Id}. {order.ReferenceNumber} Date: {order.DateTime} Location: {order.Location} Status:{order.OrderStatus}");
        foreach (var item in order.OrderedFood)
        {
          Console.WriteLine($"{item.Key} {item.Value}");
        }
        Console.WriteLine("=================================");
      }
    }
    private void ViewAllActiveOrder()
    {
      foreach (var order in orderLogic.GetActiveOrders())
      {
        Console.WriteLine($"{order.Id} {order.ReferenceNumber} Date: {order.DateTime}  DeliveryMan Id: {order.DeliveryGuyId}  Customer Id: {order.CustomerId}  Location: {order.Location} Status:{order.OrderStatus}");
        foreach (var item in order.OrderedFood)
        {
          Console.WriteLine($"{item.Key} {item.Value}");
        }
        Console.WriteLine("=================================");
      }
    }
    private void ViewAllCompletedOrders()
    {
      foreach (var order in orderLogic.GetCompletedOrders())
      {
        Console.WriteLine($"{order.Id} {order.ReferenceNumber} Date:{order.DateTime} DeliveryMan Id:{order.DeliveryGuyId} Customer Id{order.CustomerId} Location:{order.Location} Status:{order.OrderStatus}");
        foreach (var item in order.OrderedFood)
        {
          Console.WriteLine($"{item.Key} {item.Value}");
        }
        Console.WriteLine("=================================");
      }
    }
    private void ViewAllCancelledOrder()
    {
      foreach (var order in orderLogic.GetCancelledOrders())
      {
        Console.WriteLine($"{order.Id} {order.ReferenceNumber} Date:{order.DateTime} DeliveryMan Id:{order.DeliveryGuyId} Customer Id{order.CustomerId} Location:{order.Location} Status:{order.OrderStatus}");
        foreach (var item in order.OrderedFood)
        {
          Console.WriteLine($"{item.Key} {item.Value}");
        }
        Console.WriteLine("=================================");
      }
    }
    private void ViewAllCustomer()
    {
      foreach(var customer in customerLogic.GetAll())
      {
        Console.WriteLine($"{customer.Id}. {customer.FirstName} {customer.LastName} {customer.Email} {customer.Gender}");
      }
    }
    private void ViewStaffById()
    {
      Console.WriteLine("Enter staff Id");
      int id = int.Parse(Console.ReadLine()!);
      var staff = staffLogic.Get(id);
      if (staff != null)
        Console.WriteLine($"{staff.Id} {staff.FirstName} {staff.LastName} {staff.Email} {staff.Address} {staff.PhoneNumber} {staff.Gender}");
      else
        Console.WriteLine("Not Found");
    }
    private void ViewStaffByEmail()
    {
      Console.WriteLine("Enter Email:");
      string email = Console.ReadLine()!;
      var staff = staffLogic.GetStaffByEmail(email);
      if (staff != null)
        Console.WriteLine($"{staff.Id} {staff.FirstName} {staff.LastName} {staff.Email} {staff.Address} {staff.PhoneNumber} {staff.Gender}");
      else
        Console.WriteLine("Not Found");
    }
    private void ViewFoodById()
    {
      Console.WriteLine("Enter food id");
      int id = int.Parse(Console.ReadLine()!);
      var food = foodLogic.Get(id);
      if (food != null)
        Console.WriteLine($"{food.Id}  {food.Name}  {food.Description} Category Id: {food.CategoryId} ${food.UnitPrice}");
      else
        Console.WriteLine("Not Found");
    }
    private void ViewFoodByName()
    {
      Console.WriteLine("Enter food name");
      string name = Console.ReadLine()!;
      var food = foodLogic.GetFoodByName(name);
      if (food != null)
        Console.WriteLine($"{food.Id}  {food.Name}  {food.Description} Category Id: {food.CategoryId} ${food.UnitPrice}");
      else
        Console.WriteLine("Not Found");
    }
    private void ViewCategoryById()
    {
      Console.WriteLine("Enter Category id");
      int id = int.Parse(Console.ReadLine()!);
      var category = categoryLogic.Get(id);
      if(category != null)
        Console.WriteLine($"{category.Id}. {category.Name} {category.Description} ");
      else
        Console.WriteLine("Not Found");
    }
    private void ViewCategoryByName()
    {
      Console.WriteLine("Enter Category name");
      string name = Console.ReadLine()!;
      var category = categoryLogic.GetbyName(name);
    }
    private void ViewAllReviews()
    {
      var review = reviewLogic.GetAll();
      if (review != null)
      {
        foreach (var item in review )
        {
          Console.WriteLine($"{item.Id} FeedBack: {item.Feedback}  Order Id: {item.OrderId}  Customer Id: {item.CustomerId} ");
          foreach (var rating in item.Rating)
          {
            Console.WriteLine($"{rating.Key}  Rating: {rating.Value}");
          }
        }
      }
      else
      {
        Console.WriteLine("There's no review available");
      }

    }
    private void Update()
    {
      Console.WriteLine("1.Update DeliveryMan.\n2. Update Category.\n3. Update Food\n4. Exit");
      int choice = int.Parse(Console.ReadLine()!);
      switch (choice)
      {
        case 1:
          UpdateDeliveryMan();
          Update();
          break;
        case 2:
          UpdateCategory();
          Update();
          break;
        case 3:
          UpdateFood();
          Update();
          break;
        case 4:
          GetInformation();
          break;
        default:
          Console.WriteLine("Invalid Input");
          Update();
          break;
      }
      

    }
    private void UpdateDeliveryMan()
    {
      Console.WriteLine("Enter Email");
      string email = Console.ReadLine()!;
      Console.WriteLine("=================");
      Console.WriteLine("Enter first name");
      string firstName = Console.ReadLine()!;
      Console.WriteLine("Enter last name");
      string lastName = Console.ReadLine()!;
      Console.WriteLine("Enter middle name");
      string middleName = Console.ReadLine()!;
      Console.WriteLine("Enter phone number");
      string phoneNumber = Console.ReadLine()!;
      Console.WriteLine("Enter address");
      string address = Console.ReadLine()!;
      bool response = deliveryManLogic.Update(email,firstName,lastName,middleName,phoneNumber,address);
      if (response)
        Console.WriteLine("Profile updated successfully");
      Console.WriteLine($"First Name: {firstName} \nLastName: {lastName} \nMiddleName: {middleName} \nPhone Number: {phoneNumber} {address}");

    }
    private void UpdateCategory()
    {
      Console.WriteLine("Select category to edit...");
      foreach (var category in categoryLogic.GetAll())
      {
        Console.WriteLine($"{category.Id
        } {category.Name}");
      }
      int res = int.Parse(Console.ReadLine()!);
      Console.WriteLine("Enter Category Name:");
      string categoryName = Console.ReadLine()!;
      Console.WriteLine("Enter Description:");
      string description = Console.ReadLine()!;
      bool success = categoryLogic.Update(res,categoryName,description);
      if (success)
        Console.WriteLine("Updated successfully");
      Console.WriteLine($"category Name: {categoryName}\nDescription: {description}");
    }
    private void UpdateFood()
    {
      Console.WriteLine("Enter the name of food to edit:");
      string name = Console.ReadLine()!;
      var food = foodLogic.GetFoodByName(name);
      Console.WriteLine($"{food.Name} {food.Description}");
      Console.WriteLine("Edit  the food:");
      Console.WriteLine("Enter food name:");
      string foodName = Console.ReadLine()!;
      Console.WriteLine("Enter food name:");
      string description = Console.ReadLine()!;
      Console.WriteLine("Select the category by option");
      foreach (var item in categoryLogic.GetAll())
      {
        Console.WriteLine($"{item.Id} {item.Name} ");
      }
      int id = int.Parse(Console.ReadLine()!);
      var response = foodLogic.Update(food.Id,foodName, description,id);
      if(response)
      {
        Console.WriteLine("Updated successfully");
        Console.WriteLine($"category Name: {foodName}\nDescription: {description}");
      }
      else
        Console.WriteLine("Update Failed");

    }
  }
}

