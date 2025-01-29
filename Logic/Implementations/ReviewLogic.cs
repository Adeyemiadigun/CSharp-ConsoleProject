using GFood.Context;
using GFoodApp.Logic.Interfaces;
using GFoodApp.Models;

namespace GFoodApp.Logic.Implementations
{
    public class ReviewLogic : IReviewLogic
    {
   
      IOrderLogic orderLogic = new OrderLogic();
        public bool Create(int orderId, string FeedBack, Dictionary<string, int> Rating)
        {
          var reviewedOrder = orderLogic.Get(orderId);
          var review = new Review(GFoodAppContext.Reviews.Count + 1, orderId, Rating, FeedBack);
          reviewedOrder.OrderReview = review;
          var res = orderLogic.UpdateOrderList(reviewedOrder);
          GFoodAppContext.Reviews.Add(review);
          return true;
        }

        public bool Delete(int id)
        {
          foreach (var review in GFoodAppContext.Reviews)
          {
            if (review.Id == id)
            {
                GFoodAppContext.Reviews.Remove(review);
                return true;
            }
          }
          return false;
        }

        public List<Review> GetAll()
        {
          return GFoodAppContext.Reviews;
        }

        public List<Review> GetAllCustomerReviews()
        {
          List<Review> reviewList = new List<Review>();
            foreach (var order in orderLogic.GetCompletedOrders())
            {
              if(order.OrderReview != null)
              {
                reviewList.Add(order.OrderReview);
              }
            }
          return reviewList;
        }
    }
}