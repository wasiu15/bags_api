using bag_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bag_api.Repositories
{
    public class BagRepository : IBagRepository
    {
        private readonly BagContext _context;

        public BagRepository(BagContext context)
        {
            _context = context;
        }
        public async Task<Bag> Create(Bag bag)
        {
            _context.Bags.Add(bag);
            await _context.SaveChangesAsync();

            return bag;
        }

        public async Task Delete(int id)
        {
            var bagToDelete = await _context.Bags.FindAsync(id);
            _context.Bags.Remove(bagToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bag>> Get()
        {
            return await _context.Bags.ToListAsync();
        }

        public async Task<Bag> Get(int id)
        {
            return await _context.Bags.FindAsync(id);
        }

        public async Task Update(Bag bag)
        {
            _context.Entry(bag).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
