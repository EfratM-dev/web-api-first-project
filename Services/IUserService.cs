using Entities;

namespace Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> Get();
        Task<User> GetById(int id);
        Task<User> Login(LoginUser loginUser);
        Task<User> Post(User user);
        Task Put(int id, User userToUpdate);
    }
}