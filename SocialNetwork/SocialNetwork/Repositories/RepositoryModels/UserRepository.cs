using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SocialNetwork.Repositories.RepositoryModels
{
    public class UserRepository : IRepository<User>
    {
        private SocialNetworkContext _context;

        public UserRepository(SocialNetworkContext context)
        {
            _context = context;
        }

        public bool Add(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddAsync(User item)
        {
            throw new NotImplementedException();
        }

        public User Find(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindAsync(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}