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
    public class PhotosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProponoDbContext _context;

        public PhotosController(IMapper mapper, ProponoDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Photos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoGetDTO>>> GetPhotos()
        {
            var photos = await _context.Photos.ToListAsync();
            var mappedPhotos = _mapper.Map<List<PhotoGetDTO>>(photos);
            return mappedPhotos;
        }

        // GET: api/Photos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoGetDTO>> GetPhoto(int id)
        {
            var photo = await _context.Photos.FindAsync(id);

            if (photo == null)
            {
                return NotFound();
            }
            var mappedPhoto = _mapper.Map<PhotoGetDTO>(photo);
            
            return mappedPhoto;
        }

        // PUT: api/Photos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoto(int id, PhotoCreateDTO photoCreateDTO)
        {
            //TODO: Create a new photo DTO to update the photo, need to update "UpdateTime" etc
            var photo = _mapper.Map<Photo>(photoCreateDTO);
            if (id != photo.Id)
            {
                return BadRequest();
            }

            _context.Entry(photo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // POST: api/Photos
        [HttpPost("{collectionId}")]
        public async Task<ActionResult<PhotoGetDTO>> PostPhoto(int collectionId, PhotoCreateDTO photoCreateDTO)
        {
            var collection = await _context.Collections.FindAsync(collectionId);
            if (collection == null)
            {
                return NotFound("Collection not found");
            }

            var photo = _mapper.Map<Photo>(photoCreateDTO);
            collection.UpdateDate = DateTime.Now;
            photo.Collection = collection;
            photo.UploadDate = DateTime.Now;

            _context.Photos.Add(photo);
            await _context.SaveChangesAsync();

            var mappedPhoto = _mapper.Map<PhotoGetDTO>(photo);
            return CreatedAtAction("GetPhoto", new { id = photo.Id }, mappedPhoto);
        }

        // DELETE: api/Photos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            var photo = await _context.Photos.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }

            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotoExists(int id)
        {
            return _context.Photos.Any(e => e.Id == id);
        }
    }
}
