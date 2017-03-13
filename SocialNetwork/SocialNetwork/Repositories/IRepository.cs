using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories
{
    public interface IRepository<T>
    {
        T Find(int key);
        Task<T> FindAsync(int key);

        bool Remove(int id);
        Task<bool> RemoveAsync(int id);

        int Update(T item);
        Task<int> UpdateAsync(T item);

        bool Add(T item);
        Task<bool> AddAsync(T item);
    }
}
