using ConsoleProject.Models.Enums;
using GFood.Context;
using GFoodApp.Logic.Interfaces;
using GFoodApp.Models;
namespace GFoodApp.Logic.Implementations
{
    public class OrderLogic : IOrderLogic
    {
      IDeliveryManLogic deliveryManLogic = new DeliveryManLogic();
      IUserLogic userLogic = new UserLogic();
      ICustomerLogic customerLogic = new CustomerLogic();
      IStaffLogic staffLogic = new StaffLogic();
        public void Create(DateTime dateTime, Dictionary<string, int> orderedFood, int deliveryManId,decimal amount,string location)
        {
          var user = userLogic.GetCurrentUser();
          var customer = customerLogic.GetCustomerByEmail(user!.Email);
          Order order = new Order(GFoodAppContext.Orders.Count+1, GenReferenceNum(),dateTime,deliveryManId, customer.Id, orderedFood,amount,location);
          GFoodAppContext.ActiveOrders.Add(order);

          GFoodAppContext.Orders.Add(order);
        }
        private static string GenReferenceNum()
        {
          return "REF-" + Guid.NewGuid().ToString("D").Substring(0, 8);
    }

        public bool Delete(int id)
        {
          foreach (var order in GFoodAppContext.Orders)
          {
            if (order.Id == id)
            {
              GFoodAppContext.Orders.Remove(order);
              return true;
            }
          }
          return false;
        }

        public Order Get(int id)
        {
          foreach(var order in GFoodAppContext.Orders)
          {
            if(order.Id == id)
            return order;
          }
          return null!;
        }

        public List<Order> GetAll()
        {
          return GFoodAppContext.Orders;
        }

        public bool SetDeliveryStatus()
        {
          var user = userLogic.GetCurrentUser();
          var staff = staffLogic.GetStaffByEmail(user!.Email);
          var deliveryMan = deliveryManLogic.GetDeliveryManByStaffId(staff.Id);
          foreach (var order in GFoodAppContext.ActiveOrders)
          {
            if(order.DeliveryGuyId == deliveryMan.Id)
            {
              order.OrderStatus = OrderStatus.Delivered;
              for (var i = 0; i < GFoodAppContext.Orders.Count; i++)
              {
                if (GFoodAppContext.Orders[i].Id == order.Id)
                  GFoodAppContext.Orders[i] = order;
              }
              GFoodAppContext.ActiveOrders.Remove(order);
              deliveryMan.IsAvailable = true;
              for(int i = 0; i < GFoodAppContext.DeliveryGuys.Count; i++)
              {
                if(GFoodAppContext.DeliveryGuys[i].Id == deliveryMan.Id)
                GFoodAppContext.DeliveryGuys[i] = deliveryMan;
              }
              GFoodAppContext.CompletedOrders.Add(order);
              return true;
            }
          }
          return false;
        }
        

        public bool CancelOrder()
        {
          var user = userLogic.GetCurrentUser();
          var customer = customerLogic.GetCustomerByEmail(user!.Email);
          foreach (var order in GFoodAppContext.ActiveOrders)
          {
            if (order.CustomerId == customer.Id)
            {
              var deliveryMan = deliveryManLogic.Get(order.DeliveryGuyId);
              deliveryMan.IsAvailable = true;
              for (int i = 0; i < GFoodAppContext.DeliveryGuys.Count; i++)
              {
                if (GFoodAppContext.DeliveryGuys[i].Id == deliveryMan.Id)
                  GFoodAppContext.DeliveryGuys[i] = deliveryMan;
              }
              GFoodAppContext.ActiveOrders.Remove(order);
              order.OrderStatus = OrderStatus.Cancelled;
              for (var i = 0; i < GFoodAppContext.Orders.Count; i++)
              {
                if (GFoodAppContext.Orders[i].Id == order.Id)
                  GFoodAppContext.Orders[i] = order;
              }
              GFoodAppContext.CancelledOrders.Add(order);
              return true;
            }
          }
            return false;
         }

        public List<Order> GetCustomerOrders()
        {
          List<Order> orders = new List<Order>();
          var user = userLogic.GetCurrentUser();
          var customer = customerLogic.GetCustomerByEmail(user!.Email);
          foreach (var order in GFoodAppContext.Orders)
          {
            if(order.CustomerId == customer.Id)
            {
              orders.Add(order);
            }
          }
          return orders;
        }
        public List<Order> GetActiveOrders()
        {
          return GFoodAppContext.ActiveOrders;
        }

        public List<Order> GetCompletedOrders()
        {
          return GFoodAppContext.CompletedOrders;
        }
    public List<Order> GetUserCompletedOrders()
    {
      var currentusercompleted = GFoodAppContext.CompletedOrders;
      var user = userLogic.GetCurrentUser();
      var customer = customerLogic.GetCustomerByEmail(user!.Email);
      foreach (var order in currentusercompleted)
      {
        if (order.CustomerId != customer.Id )
        {
          currentusercompleted.Remove(order);
        }
      }
      return currentusercompleted;
    }
    public List<Order> GetUserCompletedOrdersWithoutReview()
    {
      if(GFoodAppContext.CompletedOrders.Count > 0)
      {
        var currentusercompleted = GetUserCompletedOrders();
        foreach (var order in currentusercompleted)
        {
          if (order.OrderReview != null)
          {
            currentusercompleted.Remove(order);
          }
        }
        return currentusercompleted;
      }
      return null!;
    }

    public List<Order> GetCancelledOrders()
        {
          return GFoodAppContext.CancelledOrders;
        }

        public bool UpdateOrderList(Order order)
        {
            int high = GFoodAppContext.Orders.Count -1;
            int low = 0;
            int target = order.Id;
            while (low <= high)
            {
              int mid = (low + high)/2;
              Order guess = GFoodAppContext.Orders[mid];
              if(guess.Id < target) 
                low = mid +1;
              if(guess.Id > target)
                high = mid - 1;
              if(guess.Id == target)
              {
                GFoodAppContext.Orders[mid] = order;
                return true;
              }
            }
            return false;
        }
    }
}
              