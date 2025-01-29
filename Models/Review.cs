namespace GFoodApp.Models
{
  public class Review
  {
    public int Id { get; set; }
    public int OrderId { get; set;}
    public int CustomerId { get; set; }
    public Dictionary<string,int> Rating { get; set; } = new Dictionary<string,int>();
    public string Feedback { get; set;}

    public Review(int id, int orderId, Dictionary<string,int> rating, string feedback)
    {
      Id = id;
      OrderId = orderId;
      Rating = rating;
      Feedback = feedback;
    }
  }
}