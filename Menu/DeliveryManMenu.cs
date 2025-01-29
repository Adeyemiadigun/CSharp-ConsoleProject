using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GFoodApp.Logic.Interfaces;
using GFoodApp.Logic.Implementations;

namespace GFoodApp.Menu
{
    public partial class MainMenu
    {
        public void DeliveryManMainMenu()
        {   
            Console.WriteLine($"Welcome {deliveryManLogic.GetDeliveryManName()}");
            Console.WriteLine("Please choose an option:\n1. Check if assigned to order\n2. Mark order as Success\n3. Log Out");
            int choice = int.Parse(Console.ReadLine()!);
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    CheckAssignedOrder();
                    DeliveryManMainMenu();
                    break;
                case 2:
                    Console.Clear();
                    MarkOrderAsSuccess();
                    DeliveryManMainMenu();
                    break;
                case 3:
                    Start();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    DeliveryManMainMenu();
                    break;
            }
    
        }
        private void CheckAssignedOrder()
        {
            var order = deliveryManLogic.CheckAssigedOrder();
            if (order != null)
            {
                Console.WriteLine($"{order.DateTime} {order.ReferenceNumber} {order.Location}");
                return ;
            }
            Console.WriteLine("Not assigned to any order");
        }
        private void MarkOrderAsSuccess()
        {
            var res = orderLogic.SetDeliveryStatus();
            if(res)
            {
                Console.WriteLine("Order marked as delivered successfully");
            }
            else
            {
                Console.WriteLine("Failed to mark order as delivered");
            }
        }
        
    }
}