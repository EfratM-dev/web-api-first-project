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

        public async Task<IEnumerable<User>> Get()
        {
            return await userRepository.Get();
        }
        public async  Task<User> GetById(int id)
        {
            return await userRepository.GetById(id);
        }
        public async Task<User> Post(User user)
        {
            bool emailExist = await userRepository.IsEmailExist(user.Email);
            if(emailExist)
            {
                throw new Exception("Email already exist");
            }
            return await userRepository.Post(user);
        }
        public async Task<User> Login(LoginUser loginUser)
        {
            return await userRepository.Login(loginUser);
        }
        public async Task Put(int id, User userToUpdate)
        {
            await userRepository.Put(id, userToUpdate);
        }
    }
}
