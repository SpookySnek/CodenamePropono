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
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace CodenamePropono.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProponoDbContext _context;

        public UsersController(IMapper mapper, ProponoDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGetDTO>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            var mappedUsers = _mapper.Map<List<UserGetDTO>>(users);
            return mappedUsers;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGetDTO>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            var mappedUser = _mapper.Map<UserGetDTO>(user);
            
            return mappedUser;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserCreateDTO userCreateDTO)
        {
            //TODO: Create a new user DTO to update the user
            var user = _mapper.Map<User>(userCreateDTO);
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserGetDTO>> PostUser(UserCreateDTO userCreateDTO)
        {
            var user = _mapper.Map<User>(userCreateDTO);
            user.JoinDate = DateTime.Now;
            user.LastLogin = DateTime.Now;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var userGetDTO = _mapper.Map<UserGetDTO>(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, userGetDTO);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
