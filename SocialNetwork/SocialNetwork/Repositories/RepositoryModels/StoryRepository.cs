using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Configuration;

namespace SocialNetwork.Repositories.RepositoryModels
{
    public class StoryRepository : IStoryRepository
    {
        private SocialNetworkContext _context;
        private int _perPage = int.Parse(WebConfigurationManager.AppSettings["ItemsPerPage"]);

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

        public IEnumerable<Story> GetAll(int page)
        {
            try
            {
                return _context.Stories.Skip((page - 1) * _perPage).Take(_perPage).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Story>> GetAllAsync(int page)
        {
            try
            {
                return await _context.Stories.Skip((page - 1) * _perPage).Take(_perPage).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Story> GetAllByUserId(string Id, int page)
        {
            try
            {
                return _context.Stories.Where(x => String.Compare(x.UserId, Id, true) == 0).OrderBy(x=>x.Id)
                    .Skip((page - 1) * _perPage).Take(_perPage).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Story>> GetAllByUserIdAsync(string Id, int page)
        {
            try
            {
                return await _context.Stories.Where(x => String.Compare(x.UserId, Id, true) == 0).OrderBy(x => x.Id)
                    .Skip((page - 1) * _perPage).Take(_perPage).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int GetItemCountByUserId(string Id)
        {
            try
            {
                return _context.Stories.Where(x => String.Compare(x.UserId, Id, true) == 0).Count();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int GetGroupMemberCount(int Id)
        {
            try
            {

                return (from q in _context.Stories
                        where q.GroupId == Id
                        select q.UserId).ToHashSet().Count();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetGroupStoryCount(int Id)
        {
            try
            {
                return (from q in _context.Stories
                        where q.GroupId == Id
                        select q).Count();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> GetGroupStoryCountAsync(int Id)
        {
            try
            {
                return await (from q in _context.Stories
                              where q.GroupId == Id
                              select q).CountAsync();
            }
            catch (Exception ex)
            {
                return 0;
            }
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
                entry.Property(e => e.GroupId).IsModified = true;
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