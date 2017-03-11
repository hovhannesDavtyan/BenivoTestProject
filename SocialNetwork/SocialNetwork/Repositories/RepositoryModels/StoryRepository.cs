using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SocialNetwork.Repositories.RepositoryModels
{
    public class StoryRepository : IRepository<Story>
    {
        private SocialNetworkContext _context;

        public StoryRepository(SocialNetworkContext context)
        {
            _context = context;
        }

        public bool Add(Story item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddAsync(Story item)
        {
            throw new NotImplementedException();
        }

        public Story Find(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<Story> FindAsync(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Story> GetAll()
        {
            return _context.Stories.ToList();
        }

        public async Task<IEnumerable<Story>> GetAllAsync()
        {
            return await _context.Stories.ToListAsync();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Story item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Story item)
        {
            throw new NotImplementedException();
        }
    }
}