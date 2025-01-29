namespace GFoodApp.Models
{
  public class Category
  {
    public  int Id {get; set;}
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    public Category(int id,string name, string description)
    {
      Id = id;
      Name = name;
      Description = description;
    }

  }
}