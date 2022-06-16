using bag_api.Models;
using bag_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bag_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BagsController : ControllerBase
    {
        private readonly IBagRepository _bagRepository;

        public BagsController(IBagRepository bagRepository)
        {
            _bagRepository = bagRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Bag>> GetBags()
        {
            return await _bagRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bag>> GetBags(int id)
        {
            return await _bagRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Bag>> PostBags([FromBody] Bag bag)
        {
            var newBag = await _bagRepository.Create(bag);
            return CreatedAtAction(nameof(GetBags), new { id = newBag.Id }, newBag);
        }

        [HttpPut]
        public async Task<ActionResult> PutBags(int id, [FromBody] Bag bag)
        {
            if(id != bag.Id)
            {
                return BadRequest();
            }

            await _bagRepository.Update(bag);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete (int id)
        {
            var bagToDelete = await _bagRepository.Get(id);
            if(bagToDelete != null)
            {
                return NotFound();
            }
            await _bagRepository.Delete(bagToDelete.Id);
            return NoContent();
        }
    }
}
