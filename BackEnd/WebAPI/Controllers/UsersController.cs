using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.User;

namespace WebAPI.Controllers
{
    /// <summary>
    /// API endpoints for User table. Requires authorization
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
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDTO>>> GetUsers()
        {
            return Ok(_mapper.Map<List<UserReadDTO>>(await _context.User.ToListAsync()));
        }

        /// <summary>
        /// Fetches a specific user.
        /// </summary>
        /// <param name="id">Id of the user to fetch.</param>
        /// <returns>A single user.</returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetUser(int id)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            UserReadDTO dtoUser = _mapper.Map<UserReadDTO>(user);
            return Ok(dtoUser);
        }

        [HttpGet("keycloak/{keycloak_id}")]
        public async Task<ActionResult<UserReadDTO>> GetUserByKeycloakId(string keycloak_id)
        {
            var user = await _context.User.Where(u => u.KeycloakId == keycloak_id).ToListAsync();

            if (user.Count == 0)
            {
                return NotFound();
            }
            
            UserReadDTO dtoUser = _mapper.Map<UserReadDTO>(user.First());
            return Ok(dtoUser);
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
            
            //Check if user already exists
            //var checkUser = await _context.User.FirstOrDefaultAsync(u => u.UserName.Equals(dtoUser.UserName));
            //409 for now. maybe check better error
            //if (checkUser != null) return StatusCode(409);

            User domainUser = _mapper.Map<User>(dtoUser);
            await _context.User.AddAsync(domainUser);
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
