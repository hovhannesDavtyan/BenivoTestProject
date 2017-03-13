using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories
{
    public interface IStoryRepository : IRepository<Story>
    {
        IEnumerable<Story> GetAll(int page);
        Task<IEnumerable<Story>> GetAllAsync(int page);

        IEnumerable<Story> GetAllByUserId(string Id, int page);
        Task<IEnumerable<Story>> GetAllByUserIdAsync(string Id, int page);

        int GetGroupMemberCount(int Id);

        int GetGroupStoryCount(int Id);
        Task<int> GetGroupStoryCountAsync(int Id);

        int GetItemCountByUserId(string Id);
    }
}
