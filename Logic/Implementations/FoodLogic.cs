using GFood.Context;
using GFoodApp.Logic.Implementations;
using GFoodApp.Logic.Interfaces;
using GFoodApp.Models;

namespace GFoodApp.Logic.Implementations
{
    public class FoodLogic : IFoodLogic
    {
        public bool Create(string name, string description, int categoryId, decimal unitPrice)
        {
          foreach (var food in GFoodAppContext.Foods)
          {
            if(food.Name == name)
              return false;
          }
          var newFood = new Food(GFoodAppContext.Foods.Count + 1, name, description,categoryId, unitPrice);
          GFoodAppContext.Foods.Add(newFood);
          return true;
        }

        public bool Delete(int id)
        {
          foreach (var food in GFoodAppContext.Foods)
          {
            if (food.Id == id)
            {
              GFoodAppContext.Foods.Remove(food);
              return true;
            }
          }
          return false;
        }

        public Food Get(int id)
        {
          foreach (var food in GFoodAppContext.Foods)
          {
            if (food.Id == id)
            {
              return food;
            }
          }
          return null!;
        }

        public List<Food> GetAllFoods()
        {
          return GFoodAppContext.Foods;
        }

        public Food GetFoodByName(string name)
        {
          foreach (var food in GFoodAppContext.Foods)
          {
            if (food.Name == name)
            {
              return food;
            }
          }
          return null!;
        }

        public bool Update(int id,string name, string description, int categoryId)
        {
           foreach (var food in GFoodAppContext.Foods)
          {
            if (food.Id == id)
            {
              food.Name = name;
              food.Description = description;
              food.CategoryId = categoryId;
              for (int i = 0; i < GFoodAppContext.Foods.Count; i++)
              {
                if (GFoodAppContext.Foods[i].Id == food.Id)
                  GFoodAppContext.Foods[i] = food;
              }
            return true;
            }
          }
          return false;
        }
        public List<Food> GetByCategoryId(int categoryId)
        {
          List<Food> foodList = new List<Food>();
          foreach (var food in GFoodAppContext.Foods)
          {
            if(food.CategoryId == categoryId)
            foodList.Add(food);
          }
          return foodList;
        }

        public string GetName(int id)
        {
          foreach (var food in GFoodAppContext.Foods)
          {
            if (food.Id == id)
            return food.Name;
          }
          return null!;
        }

        public void DeleteByCategoryId(int categoryId)
        {
          foreach (var item in GFoodAppContext.Foods)
          {
            if (item.CategoryId == categoryId)
            {
              GFoodAppContext.Foods.Remove(item);
            }
          }
        }
    }
}