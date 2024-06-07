using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodenamePropono.Server.Data;
using CodenamePropono.Server.DTOs.Incoming;
using CodenamePropono.Server.DTOs.Outgoing;
using CodenamePropono.Server.Models;
using MapsterMapper;

namespace CodenamePropono.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProponoDbContext _context;

        public CollectionsController(IMapper mapper, ProponoDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Collections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollectionGetDTO>>> GetCollections()
        {
            var collections = await _context.Collections.ToListAsync();
            var mappedCollections = _mapper.Map<List<CollectionGetDTO>>(collections);
            return mappedCollections;
        }

        // GET: api/Collections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CollectionGetDTO>> GetCollection(int id)
        {
            var collection = await _context.Collections.FindAsync(id);

            if (collection == null)
            {
                return NotFound();
            }
            var mappedCollection = _mapper.Map<CollectionGetDTO>(collection);
            return mappedCollection;
        }

        // PUT: api/Collections/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollection(int id, CollectionCreateDTO collectionCreateDTO)
        {
            //TODO: Create a new collection DTO to update the collection, need to update "UpdateTime" etc
            var collection = _mapper.Map<Collection>(collectionCreateDTO);
            if (id != collection.Id)
            {
                return BadRequest();
            }
            collection.UpdateDate = DateTime.Now;
            _context.Entry(collection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // POST: api/Collections
        [HttpPost("{userId}")]
        public async Task<ActionResult<CollectionGetDTO>> PostCollection(int userId, CollectionCreateDTO collectionCreateDTO)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var collection = _mapper.Map<Collection>(collectionCreateDTO);
            collection.User = user;
            collection.CreationDate = DateTime.Now;

            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();

            var mappedCollection = _mapper.Map<CollectionGetDTO>(collection);
            return CreatedAtAction("GetCollection", new { id = collection.Id }, mappedCollection);
        }

        // DELETE: api/Collections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var collection = await _context.Collections.FindAsync(id);
            if (collection == null)
            {
                return NotFound();
            }

            _context.Collections.Remove(collection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollectionExists(int id)
        {
            return _context.Collections.Any(e => e.Id == id);
        }
    }
}
