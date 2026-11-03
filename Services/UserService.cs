using Entities;
using Repository;

namespace Services
{
    public class UserService
    {
        UserRepository repository = new UserRepository();
        public IEnumerable<string> Get()
        {
            return repository.Get();
        }
        public User GetById(int id)
        {
           return repository.GetById(id);
        }
        public User Post(User user)
        {
            return repository.Post(user);
        }
        public User Login(LoginUser loginUser)
        {
            return repository.Login(loginUser);
        }
        public void Put(int id, User userToUpdate)
        {
            repository.Put(id, userToUpdate);
        }
    }
}
