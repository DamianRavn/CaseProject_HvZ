using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.User;

namespace WebAPI.Controllers
{
    /// <summary>
    /// API endpoints for User table
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly HumanVZombiesDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Adding context and mapper with dependency injection.
        /// </summary>
        /// <param name="context">The proper context.</param>
        /// <param name="mapper">The automapper.</param>
        public UsersController(HumanVZombiesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Fetches all users in the database.
        /// </summary>
        /// <returns>A list of users.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDTO>>> GetUser()
        {
            return _mapper.Map<List<UserReadDTO>>(await _context.User.ToListAsync());
        }

        /// <summary>
        /// Fetches a specific user.
        /// </summary>
        /// <param name="id">Id of the user to fetch.</param>
        /// <returns>A single user.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetUser(int id)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);

            return _mapper.Map<UserReadDTO>(user);
        }

        //// PUT: api/Users/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(int id, User user)
        //{
        //    if (id != user.id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="dtoUser">An object contining data for the new user.</param>
        /// <returns>The newly created user.</returns>
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserCreateDTO dtoUser)
        {
            User domainUser = _mapper.Map<User>(dtoUser);
            _context.User.Add(domainUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = domainUser.Id }, _mapper.Map<UserReadDTO>(domainUser));
        }

        //// DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    var user = await _context.User.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.User.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        /// <summary>
        /// Helper function to test if a user exists in the database or not.
        /// </summary>
        /// <param name="id">Id of the user to check.</param>
        /// <returns>True if the user exists; false otherwise.</returns>
        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
