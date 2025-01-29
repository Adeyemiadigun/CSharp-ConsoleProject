using ConsoleProject.Models.Enums;

namespace GFoodApp.Models
{
  public class Order
  {
    public int Id { get; set; }
    public string ReferenceNumber { get; set; }
    public  DateTime DateTime { get; set; } 
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Processed;
    public int DeliveryGuyId { get; set; } = default!;
    public int CustomerId {get; set; } = default!;
    public Dictionary<string,int> OrderedFood { get; set; } = new Dictionary<string,int>();
    public decimal Amount { get; set; } = default!;
    public string Location { get; set;}
    public Review OrderReview { get; set; } = null;

    public Order(int id, string referenceNumber, DateTime dateTime, int deliveryGuyId, int customerId,Dictionary<string,int> orderedFood, decimal amount,string location)
    {
      Id = id;
      ReferenceNumber = referenceNumber;
      DateTime = dateTime;
      DeliveryGuyId = deliveryGuyId;
      OrderedFood = orderedFood;
      CustomerId = customerId;
      Amount = amount;
      Location = location;
    }
  }
}