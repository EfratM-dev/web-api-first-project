using Entities;

namespace Services
{
    public interface IUserService
    {
        IEnumerable<string> Get();
        User GetById(int id);
        User Login(LoginUser loginUser);
        User Post(User user);
        void Put(int id, User userToUpdate);
    }
}