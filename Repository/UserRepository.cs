//This using isn't used in this file: you can remove it
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        storeDBContext storeDBContext;

        public UserRepository(storeDBContext storeDBContext)
        {
            this.storeDBContext = storeDBContext;
        }
        public async Task<IEnumerable<User>> Get()
        {
            return await storeDBContext.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await storeDBContext.Users.FindAsync(id);
        }

        public async Task<User> Post(User user)
        {
            await storeDBContext.Users.AddAsync(user);
            await storeDBContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Login(LoginUser loginUser)
        {
            return await storeDBContext.Users.Where(user => user.Email == loginUser.Email && user.Password == loginUser.Password).FirstOrDefaultAsync();
        }

        public async Task Put(int id, User userToUpdate)
        { 
            userToUpdate.Id = id;
            storeDBContext.Users.Update(userToUpdate);
            await storeDBContext.SaveChangesAsync();
        }
    }
}
