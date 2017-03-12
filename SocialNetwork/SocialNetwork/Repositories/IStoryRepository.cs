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
        IEnumerable<Story> GetAllByUserId(string Id);
        Task<IEnumerable<Story>> GetAllByUserIdAsync(string Id);

        int GetGroupMemberCount(int Id);

        int GetGroupStoryCount(int Id);
        Task<int> GetGroupStoryCountAsync(int Id);
    }
}
