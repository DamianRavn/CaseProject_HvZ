using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.KillsTable;

namespace WebAPI.Controllers
{
    /// <summary>
    /// The controller holds all the API endpoints for the Games table.
    /// </summary>
    [Route("api/Kills")]
    [ApiController]
    public class KillsTablesController : Controller
    {
        private readonly HumanVZombiesDbContext _context;
        private readonly IMapper _mapper;

        public KillsTablesController(HumanVZombiesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Fetches all kills from the database.
        /// </summary>
        /// <returns>A collection of games.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<KillsReadDTO>>> GetKills()
        {
            return _mapper.Map<List<KillsReadDTO>>(await _context.KillsTable
                .Include(g => g.Users)
                .ToListAsync());
        }

        /// <summary>
        /// Fetches a specific kill in the database.
        /// </summary>
        /// <param name="id">The id of the kill to fetch.</param>
        /// <returns>The kill, if it exists. Otherwise, the NotFound response.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<KillsReadDTO>> GetKill(int id)
        {
            if (!KillsTableExists(id))
            {
                return NotFound();
            }

            var kill = await _context.KillsTable
                .Include(g => g.Users)
                .Where(g => g.Id == id)
                .ToListAsync();

            return _mapper.Map<KillsReadDTO>(kill.First());
        }

        /// <summary>
        /// Creates a new kill based on the given kill object.
        /// </summary>
        /// <param name="dtoGame">The kill object.</param>
        /// <returns>The newly created kill.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<KillsTable>> PostKill(KillsCreateDTO dtoKill)
        {
            KillsTable domainKill = _mapper.Map<KillsTable>(dtoKill);

            _context.KillsTable.Add(domainKill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGame", new { id = domainKill.Id },
                                   _mapper.Map<KillsReadDTO>(domainKill));
        }

        /// <summary>
        /// Updates a specific kill with the values of the given kill object.
        /// </summary>
        /// <param name="id">The id of the kill to update.</param>
        /// <param name="dtoKill">A kill object containing the updated values.</param>
        /// <returns>Nothing if the update succeeds. BadRequest if the given id doesn't match the id of a kill. NotFound if the kill doesn't exist.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutKill(int id, KillsUpdateDTO dtoKill)
        {
            if (id != dtoKill.Id)
            {
                return BadRequest();
            }

            KillsTable domainGame = _mapper.Map<KillsTable>(dtoKill);

            _context.Entry(domainGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KillsTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Helper function, which checks if a kill with the given id exists.
        /// </summary>
        /// <param name="id">The id to check for.</param>
        /// <returns>True if a kill with that id exists. False otherwise.</returns>
        private bool KillsTableExists(int id)
        {
            return _context.KillsTable.Any(e => e.Id == id);
        }
    }
}
