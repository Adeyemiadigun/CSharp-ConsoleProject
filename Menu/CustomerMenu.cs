namespace GFoodApp.Menu
{
    public partial class MainMenu
    {
        
        public void CustomerMainMenu()
        {   
            Console.WriteLine($"\nWelcome {customerLogic.GetCustomerName()}\n");
            CheckBalance();
            Console.WriteLine("\nPlease choose an option:\n1. Deposit \n2Make Order\n3. Check Order History\n4. Cancel Order\n5. Give Review to order\n6. View All Review\n7. Update Profile\n8. Delete Account\n9. LogOut");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Deposit();
                    CustomerMainMenu();
                    break;
                case 2:
                    Console.Clear();
                    Order();
                    CustomerMainMenu();
                    break;
                case 3:
                    Console.Clear();
                    CheckOrderHistory();
                    CustomerMainMenu();
                    break;
                case 4:
                    Console.Clear();
                    CancelOrder();
                    CustomerMainMenu();
                    break;
                case 5:
                    Console.Clear();
                    GiveOrderReview();
                    CustomerMainMenu();
                    break;
                case 6:
                    Console.Clear();
                    ViewAllReview();
                    CustomerMainMenu();
                    break;
                case 7:
                    Console.Clear();
                    UpdateProfile();
                    CustomerMainMenu();
                    break;
                case 8:
                    Console.Clear();
                    DeleteAccount();
                    break;
                case 9:
                    Console.Clear();
                    Start();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    CustomerMainMenu();
                    break;
            }

            
        }
        private void Deposit()
        {
            Console.WriteLine("Enter amount to deposit");
            decimal amount = decimal.Parse(Console.ReadLine()!);
            bool response = walletLogic.Deposit(amount);
            if(response)
                Console.WriteLine("Deposit successful");
            else
                Console.WriteLine("Deposit failed");
        }
        private void CheckBalance()
        {
            Console.WriteLine($"$Balance: {walletLogic.GetBalance()}");
        }
        private void Order()
        {
            Dictionary<string,int> selectedOrder = new Dictionary<string,int>();
            decimal amount = 0 ;
            while(true)
            {
                foreach (var category in categoryLogic.GetAll())
                {
                    Console.WriteLine($"{category.Id} {category.Name}  Description:{category.Description}");
                }
                int id  = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Available Foods ⇓\n Select food by entering the specified number of food");

                foreach (var foods in foodLogic.GetByCategoryId(id))
                {
                    Console.WriteLine($"{foods.Id}.  Food Name: {foods.Name}  Description: {foods.Description}  Unit Price: ${foods.UnitPrice}");
                }
                int choice = Convert.ToInt32(Console.ReadLine());
                string foodName = foodLogic.GetName(choice);
                Console.WriteLine("Enter Quantity:");
                int quantity = int.Parse(Console.ReadLine()!);
                if(selectedOrder.ContainsKey(foodName))
                    selectedOrder[foodName] += quantity;
                else
                    selectedOrder.Add(foodName, quantity);
                Console.WriteLine("Do you want to purchase another food(yes/no): ");
                string answer = Console.ReadLine()!;
                if(answer.ToLower() == "no")
                {
                   foreach (var item in selectedOrder)
                    {
                        amount += foodLogic.GetFoodByName(item.Key).UnitPrice * item.Value;
                    }
                    break;
                }
            }
            Console.WriteLine("Enter your location");
            string location = Console.ReadLine()!;
            var deliveryMan = deliveryManLogic.GetAvailableDeliveryMan();
            if (deliveryMan != null)
            {  
                 var response = walletLogic.MakePayment(amount);
                if(response)
                {
                    
                    orderLogic.Create(DateTime.Now,selectedOrder,deliveryMan.Id, amount, location);
                    Console.WriteLine("Order placed successfully");
                }
                else 
                    Console.WriteLine("Insufficient funds");
            }
            else 
            {
                Console.WriteLine("Try again later \n No available DeliveryMan");
            }
        }
        private void CheckOrderHistory()
        {
            foreach(var order in orderLogic.GetCustomerOrders())
            {
                Console.WriteLine($"{order.ReferenceNumber} Date:{order.DateTime} Location:{order.Location} Status:{order.OrderStatus}");
                foreach (var item in order.OrderedFood)
                {
                    Console.WriteLine($"{item.Key} {item.Value}");
                }
                Console.WriteLine("=================================");
            }
        }
        private void CancelOrder()
        {
            bool Cancelled = orderLogic.CancelOrder();
            if(Cancelled)
                Console.WriteLine("Order cancelled successfully");
        }
        private void UpdateProfile()
        {
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
            var customer = customerLogic.Update(firstName,lastName,middleName,phoneNumber,address);
            Console.WriteLine("Updated profile\n =====================");
            Console.WriteLine($"{firstName} \n{lastName} \n{middleName} \n{phoneNumber} \n{address}");
        }
        private void DeleteAccount()
        {
            Console.WriteLine("Are you sure you want to delete your account(yes/no)");
            string response = Console.ReadLine()!;
            if(response.ToLower() == "yes")
            {
                var user = userLogic.GetCurrentUser();
                var customer = customerLogic.GetCustomerByEmail(user!.Email);
                var res = customerLogic.Delete(customer.WalletId);
                walletLogic.Delete(customer.Id);
                if(res)
                {
                   Console.WriteLine("Account deleted successfully");
                   Start();
                } 
            }
        }
        private void GiveOrderReview()
        {
            Dictionary<string,int> ratings = new Dictionary<string,int>();
            var orderList = orderLogic.GetUserCompletedOrdersWithoutReview();
            if(orderList == null)
            {
                Console.WriteLine("No completed orders to review");
                return;
            }
            foreach (var item in orderList )
            {
                Console.WriteLine($"{item.DateTime} Id: {item.Id} {item.ReferenceNumber}  ${item.Amount} {item.Location} {item.OrderStatus}");
            }

            Console.WriteLine("Input Id to rate order");
            int id = int.Parse(Console.ReadLine()!);
            var order = orderLogic.Get(id);
            Console.WriteLine("Rate foods in order (1-5)");
            foreach (var food in order.OrderedFood)
            {  
                
                Console.WriteLine($"{food.Key} {food.Value}");
                repeat:
                Console.WriteLine("Give rating (1-5)");
                int  rating= int.Parse(Console.ReadLine()!);
                if(rating < 5 && rating > 1)
                    ratings.Add(food.Key, rating);
                else
                {
                    Console.WriteLine("Wrong Input");
                    goto repeat;
                }
            }
            Console.WriteLine("Give General review");
            string feedBack = Console.ReadLine()!;
            bool res = reviewLogic.Create(order.Id,feedBack,ratings);
            
        }
        private void ViewAllReview()
        {
            foreach (var item in reviewLogic.GetAllCustomerReviews())
            {
                Console.WriteLine($"General Review {item.Feedback} ");
                foreach (var rating in item.Rating)
                {
                    Console.WriteLine($"Food Rating: {rating.Key}  Rating: {rating.Value}");
                }
            }
        }

    }
}
               
                    


                

