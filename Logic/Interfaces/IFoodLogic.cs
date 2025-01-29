using GFoodApp.Models;

namespace GFoodApp.Logic.Interfaces
{
  public interface IFoodLogic
  {
     bool Create(string name, string description, int categoryId,decimal unitPrice);
     Food GetFoodByName(string name);
     List<Food> GetAllFoods();
     List<Food> GetByCategoryId(int categoryId);
     Food Get(int id) ;
     bool Update(int id,string name, string description, int categoryId);
     bool Delete (int id);
     string GetName(int id);
     void DeleteByCategoryId(int categoryId);
  }
}
