using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        IEnumerable<string> Get();
        User GetById(int id);
        User Login(LoginUser loginUser);
        User Post(User user);
        void Put(int id, User userToUpdate);
    }
}