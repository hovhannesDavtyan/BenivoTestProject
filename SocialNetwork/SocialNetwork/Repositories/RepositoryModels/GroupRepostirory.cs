using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories.RepositoryModels
{
    public class GroupRepostirory : IRepository<Group>
    {
        private SocialNetworkContext _context;

        public GroupRepostirory(SocialNetworkContext context)
        {
            _context = context;
        }

        public bool Add(Group item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddAsync(Group item)
        {
            throw new NotImplementedException();
        }

        public Group Find(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<Group> FindAsync(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetAll()
        {
            return _context.Groups.ToList();
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Group item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Group item)
        {
            throw new NotImplementedException();
        }
    }
}