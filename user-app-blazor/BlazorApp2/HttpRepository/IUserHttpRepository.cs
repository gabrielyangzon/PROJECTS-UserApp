using BlazorApp2.Models;

namespace BlazorApp2.HttpRepository
{
    public interface IUserHttpRepository
    {
        Task<List<UserModel>> GetUsers();
        Task<UserModel> GetUserById(string userId);

        Task<bool> EditUser(UserModel user);

        Task<bool> AddUser(UserModel user);

        Task<bool> DeleteUser(string userId);
    }
}
