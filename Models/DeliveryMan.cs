namespace GFoodApp.Models
{
  public class DeliveryMan
  {
    public int Id { get; set; }
    public int StaffId { get; set;}
    public string PlateNumber { get; set; }
    public bool IsAvailable { get; set; } = true;
    public DeliveryMan(int id,int staffId, string plateNumber)
    {
      Id = id;
      StaffId = staffId;
      PlateNumber = plateNumber;
    }
  }
}
    