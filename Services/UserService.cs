using Entities;
using Repository;

namespace Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<string> Get()
        {
            return userRepository.Get();
        }
        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }
        public User Post(User user)
        {
            return userRepository.Post(user);
        }
        public User Login(LoginUser loginUser)
        {
            return userRepository.Login(loginUser);
        }
        public void Put(int id, User userToUpdate)
        {
            userRepository.Put(id, userToUpdate);
        }
    }
}
