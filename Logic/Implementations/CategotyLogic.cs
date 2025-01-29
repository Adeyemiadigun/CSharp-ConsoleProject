using GFood.Context;
using GFoodApp.Logic.Interfaces;
using GFoodApp.Models;

namespace GFoodApp.Logic.Implementations
{
    public class CategoryLogic : ICategoryLogic
    {
        public bool Create(string name, string description)
        {
          foreach (var category in GFoodAppContext.Categories)
          {
            if(category.Name == name)
            return false;
          }
          var newCategory = new Category(GFoodAppContext.Categories.Count+1,name,description);
          GFoodAppContext.Categories.Add(newCategory);
          return true;
        }

        public bool Delete(int id)
        {
          foreach (var item in GFoodAppContext.Categories)
          {
            if (item.Id == id)
            {
              GFoodAppContext.Categories.Remove(item);
              return true;
            }
          }
          return false;
        }

        public Category Get(int id)
        {
          foreach (var category in GFoodAppContext.Categories)
          {
            if (category.Id == id)
              return category;
          }
          return null!;
        }

        public List<Category> GetAll()
        {
           return GFoodAppContext.Categories;
        }

        public Category GetbyName(string name)
        {
          foreach (var item in GFoodAppContext.Categories)
          {
            if (item.Name == name)
              return item;
          }
          return null!;
        }

        public bool Update(int id, string name, string description)
        {
          foreach (var category in GFoodAppContext.Categories)
          {
            if (category.Id==id)
            {
              category.Name = name;
              category.Description = description;
              for (int i = 0; i < GFoodAppContext.Categories.Count; i++)
              {
                if(GFoodAppContext.Categories[i].Id == category.Id)
                  GFoodAppContext.Categories[i] = category;
              }
          return true;
            }
          }
          return false;
        }
    }
}