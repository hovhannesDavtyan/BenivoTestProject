using SocialNetwork.Models;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories
{
    public interface IGroupRepository : IRepository<Group>
    {
        int UpdateCounts(int id, int memberCount, int storyCount);
        Task<int> UpdateCountsAsync(int id, int memberCount, int storyCount);
    }
}