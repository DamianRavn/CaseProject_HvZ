using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.Domain;
using AutoMapper;
using WebAPI.Models.DTO.Admin;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    /// <summary>
    /// API endpoints for Admin table
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly HumanVZombiesDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Adding context and mapper with dependency injection.
        /// </summary>
        /// <param name="context">The proper context.</param>
        /// <param name="mapper">The automapper.</param>
        public AdminsController(HumanVZombiesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Fetches all admins in the database.
        /// </summary>
        /// <returns>A list of admins.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminReadDTO>>> GetAdmin()
        {
            return _mapper.Map<List<AdminReadDTO>>(await _context.Admin.ToListAsync());
        }

        /// <summary>
        /// Fetches a specific admin.
        /// </summary>
        /// <param name="id">Id of the admin to fetch.</param>
        /// <returns>A single admin.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminReadDTO>> GetAdmin(int id)
        {
            if (!AdminExists(id))
            {
                return NotFound();
            }

            return _mapper.Map<AdminReadDTO>(await _context.Admin.FindAsync(id));
        }

        //// PUT: api/Admins/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAdmin(int id, Admin admin)
        //{
        //    if (id != admin.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(admin).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AdminExists(id))
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
        /// Creates a new admin in the database.
        /// </summary>
        /// <param name="dtoAdmin">An object contining data for the new admin.</param>
        /// <returns>The newly created admin.</returns>
        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(AdminCreateDTO dtoAdmin)
        {
            Admin domainAdmin = _mapper.Map<Admin>(dtoAdmin);
            _context.Admin.Add(domainAdmin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = domainAdmin.Id }, _mapper.Map<AdminReadDTO>(domainAdmin));
        }

        //// DELETE: api/Admins/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAdmin(int id)
        //{
        //    var admin = await _context.Admin.FindAsync(id);
        //    if (admin == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Admin.Remove(admin);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        /// <summary>
        /// Helper function to test if a user exists in the database or not.
        /// </summary>
        /// <param name="id">Id of the user to check.</param>
        /// <returns>True if the user exists; false otherwise.</returns>
        private bool AdminExists(int id)
        {
            return _context.Admin.Any(e => e.Id == id);
        }
    }
}
