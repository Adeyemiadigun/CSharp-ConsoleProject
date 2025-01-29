namespace GFoodApp.Models
{
  public class Food
  {
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int CategoryId { get; set; } = default!;
    public decimal UnitPrice { get; set; } = default!;

    public Food(int id, string name, string description,int categoryId, decimal unitPrice)
    {
      Id = id;
      Name = name;
      Description = description;
      CategoryId = categoryId;
      UnitPrice = unitPrice;
    }

  }
}