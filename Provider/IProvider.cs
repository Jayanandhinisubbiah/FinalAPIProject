using APIProject.Models;
using APIProject.ViewModels;

namespace APIProject.Provider
{
    public interface IProvider
    {
        public UserList AddNewUser(UserList U);
        public void Edit(int CartId, Cart C);
        public Task<string> EditFood(int Id, Food C);

        public void DeleteCart(int CartId);
        public UserList Login(UserList U);
        public  Task<List<Food>> GetAll();
        public Task<Food> GetFoodById(int? id);

        public Cart AddtoCart(Cart C);
        public List<Cart> GetCartById(int UserId);
        public void ViewCart(int? UserId);
        public Cart Delete(int CartId);
        public Task<NewOrder> DispatchNewOrder(int Id);
        public void DeleteConfirmed(int CartId);
        public void EmptyList(int UserId);
        public Task<string> EmptyOrder(int OrderId);

        public List<OrderDetails> OrderDetails();
        public OrderMaster Buy(int UserId);
        public OrderMaster Payment(int OrderId, string Type);
       
        public void Pay(int OrderId, OrderMaster O);

        public OrderMaster Pay(int OrderId);
        public Task<Food> AddNewFood(Food food);

        public Cart GetCartByCartId(int CartId);

        public Task<string> DeleteFood(int FoodId);
        public List<UserList> UserDetails();

        public List<Content> GetReportById(int? UserId);
        public Task<List<NewOrder>> ViewNewOrder();
        public Task<string> DispatchOrder(int Id);


    }
}
