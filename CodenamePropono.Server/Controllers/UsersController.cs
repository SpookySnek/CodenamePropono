using CodenamePropono.Server.Data;
using CodenamePropono.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodenamePropono.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ProponoDbContext _context;
 
    public UsersController(ProponoDbContext context)
    {
        _context = context;
    }
 
    [HttpGet]
    public async Task<IEnumerable<User>> Get()
    {
        return await _context.Users.ToListAsync();
    }
}