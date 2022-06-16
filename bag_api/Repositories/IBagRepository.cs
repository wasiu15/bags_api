using bag_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bag_api.Repositories
{
    public interface IBagRepository
    {
        Task<IEnumerable<Bag>> Get();
        Task<Bag> Get(int id);
        Task<Bag> Create(Bag bag);
        Task Update(Bag bag);
        Task Delete(int id);
    }
}
