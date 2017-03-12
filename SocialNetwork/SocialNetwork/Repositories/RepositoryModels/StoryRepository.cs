using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SocialNetwork.Repositories.RepositoryModels
{
    public class StoryRepository : IStoryRepository
    {
        private SocialNetworkContext _context;

        public StoryRepository(SocialNetworkContext context)
        {
            _context = context;
        }

        public bool Add(Story item)
        {
            try
            {
                _context.Stories.Add(item);
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> AddAsync(Story item)
        {
            try
            {
                _context.Stories.Add(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Story Find(int Id)
        {
            try
            {
                return _context.Stories.Where(x => x.Id.Equals(Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Story> FindAsync(int Id)
        {
            try
            {
                return await _context.Stories.Where(x => x.Id.Equals(Id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Story> GetAll()
        {
            try
            {
                return _context.Stories.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Story>> GetAllAsync()
        {
            try
            {
                return await _context.Stories.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Story> GetAllByUserId(string Id)
        {
            try
            {
                return _context.Stories.Where(x => String.Compare(x.UserId, Id, true) == 0).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Story>> GetAllByUserIdAsync(string Id)
        {
            try
            {
                return await _context.Stories.Where(x => String.Compare(x.UserId, Id, true) == 0).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int GetGroupMemberCount(int Id)
        {
            return (from q in _context.Stories
                    where q.GroupId == Id
                    select q.UserId).ToHashSet().Count();
        }

        public int GetGroupStoryCount(int Id)
        {
            return (from q in _context.Stories
                         where q.GroupId == Id
                         select q).Count();
        }

        public async Task<int> GetGroupStoryCountAsync(int Id)
        {
            return await (from q in _context.Stories
                         where q.GroupId == Id
                         select q).CountAsync();
        }

        public bool Remove(int id)
        {
            try
            {
                var stories = new Story { Id = id };
                _context.Stories.Attach(stories);
                _context.Stories.Remove(stories);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                var stories = new Story { Id = id };
                _context.Stories.Attach(stories);
                _context.Stories.Remove(stories);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Update(Story item)
        {
            try
            {
                _context.Stories.Attach(item);
                var entry = _context.Entry(item);
                entry.Property(e => e.Description).IsModified = true;
                entry.Property(e => e.Title).IsModified = true;
                entry.Property(e => e.PostedOn).IsModified = true;
                entry.Property(e => e.Content).IsModified = true;
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateAsync(Story item)
        {
            try
            {
                _context.Stories.Attach(item);
                var entry = _context.Entry(item);
                entry.Property(e => e.Description).IsModified = true;
                entry.Property(e => e.Title).IsModified = true;
                entry.Property(e => e.PostedOn).IsModified = true;
                entry.Property(e => e.Content).IsModified = true;
                entry.Property(e => e.GroupId).IsModified = true;
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}