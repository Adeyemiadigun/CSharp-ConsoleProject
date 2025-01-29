using GFoodApp.Models;

namespace GFoodApp.Logic.Interfaces
{
  public interface IReviewLogic 
  {
     bool Create(int orderId, string FeedBack, Dictionary<string,int> Rating);
     List<Review> GetAll();
     List<Review> GetAllCustomerReviews();

     bool Delete(int id);
  }
}