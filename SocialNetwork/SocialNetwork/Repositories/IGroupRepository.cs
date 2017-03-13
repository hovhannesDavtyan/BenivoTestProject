using SocialNetwork.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories
{
    public interface IGroupRepository : IRepository<Group>
    {
        IEnumerable<Group> GetAll();
        Task<IEnumerable<Group>> GetAllAsync();

        int UpdateCounts(int id, int memberCount, int storyCount);
        Task<int> UpdateCountsAsync(int id, int memberCount, int storyCount);
    }
}