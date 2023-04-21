using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;

        }
    /*  Synchronous request
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers() 
        {
            var users = _context.Users.ToList();

            return users;
        }

        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            return _context.Users.Find(id); // another simpler, cleaner code way to return the single user

           // return user; one way to return the single user
        }  
        
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            return _context.Users.Find(id); // another simpler, cleaner code way to return the single user

           // return user; one way to return the single user
        } End Synchronous request */

        // Asynchronous Request
        [AllowAnonymous]
         [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() 
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return  await _context.Users.FindAsync(id); // another simpler, cleaner code way to return the single user

           // return user; one way to return the single user
        }
    }
}