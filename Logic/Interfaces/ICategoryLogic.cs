using GFoodApp.Models;

namespace GFoodApp.Logic.Interfaces
{
  public interface ICategoryLogic
  {
     bool Create(string name, string description);
     Category Get(int id);
     Category GetbyName(string name);
     List<Category> GetAll();
     bool Update(int id,string name, string description);
     bool Delete(int id);
  }
}