using user_access;
using user_access.Repositories;

using user_data.types.Models;

namespace user_services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(USER_CONTEXT ctx)
        {
            _userRepository = new UserRepository(ctx);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await _userRepository.GetById(userId);
        }


        public async Task AddUser(User user)
        {
             await _userRepository.Add(user);
        }


        public async Task EditUser(User user)
        {
            await _userRepository.Update(user);
        }


        public async Task DeleteUser(Guid userId)
        {
            await _userRepository.Delete(userId);
        }



    }
}