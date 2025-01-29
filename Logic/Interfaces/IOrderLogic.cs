
using GFoodApp.Models;
namespace GFoodApp.Logic.Interfaces
{
  public interface IOrderLogic
  {
     void Create(DateTime dateTime, Dictionary<string, int> orderedFood, int deliveryManId,decimal amount,string location);
     bool Delete (int id);
     List<Order> GetAll();
     Order Get(int id);
     bool SetDeliveryStatus();
     bool CancelOrder();
     List<Order> GetUserCompletedOrdersWithoutReview();
     List<Order> GetCustomerOrders();
     List<Order> GetActiveOrders();
     List<Order> GetCompletedOrders();
     List<Order> GetCancelledOrders();
     bool UpdateOrderList(Order order);
  }
}