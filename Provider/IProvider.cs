using APIProject.Models;
using APIProject.ViewModels;

namespace APIProject.Provider
{
    public interface IProvider
    {
        public Task<UserList> AddNewUser(UserList U);
        public Task<bool> Edit(int CartId, Cart C);
        public Task<bool> EditFood(int Id, Food C);

        public Task<bool> DeleteCart(int CartId);
        public Task<UserList> Login(UserList U);
        public  Task<List<Food>> GetAll();
        public Task<Food> GetFoodById(int? id);

        public Task<Cart> AddtoCart(Cart C);
        public Task<List<Cart>> GetCartById(int UserId);
        public Task<bool> ViewCart(int? UserId);
        public Task<Cart> Delete(int CartId);
        public Task<NewOrder> DispatchNewOrder(int Id);
        public Task<bool> DeleteConfirmed(int CartId);
        public Task<bool> EmptyList(int UserId);
        public Task<bool> EmptyOrder(int OrderId);

        public Task<List<OrderDetails>> OrderDetails();
        public Task<OrderMaster> Buy(int UserId);
        public Task<OrderMaster> Payment(int OrderId, string Type);
       
        public Task<bool> Pay(int OrderId, OrderMaster O);

        public Task<OrderMaster> Pay(int OrderId);
        public Task<Food> AddNewFood(Food food);

        public Task<Cart> GetCartByCartId(int CartId);

        public Task<bool> DeleteFood(int FoodId);
        public List<UserList> UserDetails();

        //public List<Content> GetReportById(int? UserId);
        public Task<List<NewOrder>> ViewNewOrder();
        public Task<bool> DispatchOrder(int Id);


    }
}
