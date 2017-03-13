using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories.RepositoryModels
{
    public class GroupRepostirory : IGroupRepository
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
            try
            {
                return _context.Groups.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            try
            {
                return await _context.Groups.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Group item)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Group item)
        {
            throw new NotImplementedException();
        }

        public int UpdateCounts(int id, int memberCount, int storyCount)
        {
            try
            {
                Group group = new Group();
                group.Id = id;
                group.MemberCount = memberCount;
                group.StoryCount = storyCount;
                _context.Groups.Attach(group);
                var entry = _context.Entry(group);
                entry.Property(e => e.MemberCount).IsModified = true;
                entry.Property(e => e.StoryCount).IsModified = true;
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateCountsAsync(int id, int memberCount, int storyCount)
        {
            try
            {
                Group group = new Group();
                group.Id = id;
                group.MemberCount = memberCount;
                group.StoryCount = storyCount;
                _context.Groups.Attach(group);
                var entry = _context.Entry(group);
                entry.Property(e => e.MemberCount).IsModified = true;
                entry.Property(e => e.StoryCount).IsModified = true;
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}