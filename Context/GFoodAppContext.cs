using ConsoleProject.Models.Enums;
using GFoodApp.Models;
namespace GFood.Context
{
  public class GFoodAppContext
  {
    public static List<User> Users = new List<User>()
    {
      new User(1,"Admin","Admin","GF_SuperAdmin"),
      new User(2,"ghost@yopmail.com","qwerty","GF_Customer"),
      new User(3,"qwerty","qwerty","GF_Customer"),
      new User(4,"Jane@gmail.com","password","GF_DeliveryMan"),
      new User(5,"John@gmail.com","password","GF_DeliveryMan"),
      

    };
    public static List<Staff> Staffs = new List<Staff>()
    {
      new Staff(1,"Jane ","Doe","adigun","Jane@gmail.com","08077777777","abeokuta",Gender.Female),
      new Staff(2,"John ","Doe","adigun","John@gmail.com","08077777777","abeokuta",Gender.Male),
    };
    public static List<Category> Categories = new List<Category> ()
    {
      new Category(1,"Swallow","Starchy Foods for Eating with Soups"),
      new Category(2,"Rice Dishes","They bring life to every swallow and are loved for their rich taste and variety"),
      new Category(3,"Soups and Stews","We have one of the best delicacy"),
      new Category(4,"Snacks and Small Chops","We Perfect for on-the-go munching or as party appetizers"),
      new Category(5,"Street Foods"," Each bite is a taste of the vibrant culture"),
    };
    public static List<Food> Foods = new List<Food>()
    {
      new Food(1,"Pounded Yam","Fluffy and smooth, made from freshly pounded yam tubers",1,3000),
      new Food(2,"Amala","Best combo with ewedu and meat stew",1,4000),
      new Food(3,"Eba","Granules of cassava soaked in hot water to form a stretchy delight",1,1000),
      new Food(4,"Fufu"," Fermented cassava turned into a chewy, elastic base for soups",1,500),
      new Food(5,"Semovita"," A refined and silky swallow made from wheat",1,500),
      new Food(6,"Jollof Rice","Smoky, spicy, and rich with tomatoes and peppers, a national treasure at every event",2,5500),
      new Food(7,"Fried Rice","Colorful, with mixed vegetables and proteins, often served alongside Jollof.",2,5500),
      new Food(8,"Ofada Rice","Locally grown rice with a distinct aroma, paired with a spicy green pepper sauce.",2,6500),
      new Food(9,"Coconut Rice","Creamy and tropical, cooked with coconut milk for a unique flavor.",2,4500),
      new Food(10,"White Rice and Stew","A classic, paired with a hearty tomato-based stew.",2,3500),
      new Food(11,"Egusi Soup"," Creamy melon seed soup spiced with crayfish and cooked with spinach or bitter leaves.",3,500),
      new Food(12,"Okra Soup"," Creamy melon seed soup spiced with crayfish and cooked with spinach or bitter leaves.",3,500),
      new Food(13,"Ogbono Soup","Nutty and thick, made from ground wild mango seeds and seasoned to perfection.",3,500),
      new Food(14,"Banga Soup"," A delicacy from the Niger Delta, made with palm nut extract and aromatic spices..",3,1500),
      new Food(15,"Efo Riro","A vibrant, spicy vegetable soup loaded with spinach, fish, and meats.",3,1120),
      new Food(16,"Puff-Puff","Golden-brown, fluffy balls of fried dough with a hint of sweetness.",4,120),
      new Food(17,"Akara(Bean Cake)","Crispy on the outside, soft inside, made from spiced bean paste.",4,100),
      new Food(18,"Meat Pie","Buttery pastry filled with spiced ground beef and vegetables.",4,500),
      new Food(19,"Chin Chin","Crunchy, sweet fried dough cubes that melt in your mouth.",4,500),
      new Food(21,"Roasted Plantain","Smoky, caramelized plantains served with groundnut or pepper sauce.",5,300),
      new Food(22,"Roasted Corn","Charred and slightly sweet, eaten straight from the cob.",5,200),
      new Food(23,"Abacha (African Salad)","A tangy mix of cassava, vegetables, and spicy palm oil dressing.",5,400),
      new Food(24,"Moi Moi","Steamed bean pudding with a soft, savory texture, often spiced with fish or eggs.",5,200),
      new Food(25,"Zobo Drink"," A refreshing hibiscus tea spiced with cloves and ginger, served chilled.",5,200),

    };
    public static List<DeliveryMan> DeliveryGuys = new List<DeliveryMan>()
    {
      new DeliveryMan(1,1,"lag123qw"),
      new DeliveryMan(2,2,"lag123qw")
    };
    public static List<Customer> Customers = new List<Customer>()
    {
      new Customer(1,"qwerty","qwerty","qwerty","qwerty","qwerty","qwerty",1,Gender.Male)
    };
    public static List<Wallet> Wallets = new List<Wallet>()
    {
      new Wallet(1)
    };
    public static List<Order> Orders = new List<Order>();
    public static List<Review> Reviews = new List<Review>();
    public static List<Order> ActiveOrders = new List<Order>();
    public static List<Order> CompletedOrders = new List<Order>();
    public static List<Order> CancelledOrders = new List<Order>();
  }
}