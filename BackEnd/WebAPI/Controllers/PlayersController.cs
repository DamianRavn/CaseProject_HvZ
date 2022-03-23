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
using WebAPI.Models.DTO.Player;

namespace WebAPI.Controllers
{
    /// <summary>
    /// The controller holds all the API endpoints for the Players table
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PlayersController : Controller
    {
        private readonly HumanVZombiesDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Adding context and mapper with dependency injection.
        /// </summary>
        /// <param name="context">The proper context</param>
        /// <param name="mapper">The automapper</param>
        public PlayersController(HumanVZombiesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Fetches all players in the database.
        /// </summary>
        /// <returns>A collection of players.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PlayerReadDTO>>> GetPlayers()
        {
            return _mapper.Map<List<PlayerReadDTO>>(await _context.Players
                .ToListAsync());
        }

        /// <summary>
        /// Fetches a specific player in the database.
        /// </summary>
        /// <param name="id">The id of the player to fetch.</param>
        /// <returns>The player, if it exists. Otherwise, the NotFound response.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlayerReadDTO>> GetPlayer(int id)
        {
            //TODO: remember to authorize
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return _mapper.Map<PlayerReadDTO>(player);
        }

        /// <summary>
        /// Updates a specific player with the values of the given player object.
        /// </summary>
        /// <param name="id">The id of the player to update.</param>
        /// <param name="dtoPlayer">A player object containing the updated values.</param>
        /// <returns>Nothing if the update succeeds. BadRequest if the given id doesn't match the id of the player. NotFound if the player doesn't exist.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutPlayer(int id, PlayerUpdateDTO dtoPlayer)
        {
            if (id != dtoPlayer.Id)
            {
                return BadRequest();
            }

            Player domainPlayer = _mapper.Map<Player>(dtoPlayer);

            _context.Entry(domainPlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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
        /// Creates a new player based on the given player object.
        /// </summary>
        /// <param name="dtoPlayer">The player object.</param>
        /// <returns>The newly created player.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Player>> PostPlayer(PlayerCreateDTO dtoPlayer)
        {
            Player domainPlayer = _mapper.Map<Player>(dtoPlayer);
            _context.Players.Add(domainPlayer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = domainPlayer.Id },
                                   _mapper.Map<PlayerReadDTO>(domainPlayer));
        }

        /// <summary>
        /// Deletes the player with the given id.
        /// </summary>
        /// <param name="id">The id of the player to delete.</param>
        /// <returns>Nothing if the deletion succeeds. NotFound if no player with the given id exist.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        /// <summary>
        /// Fetches all players in the database by a non-admin user. Doesn't display BiteCode and IsPatientZero attributes.
        /// </summary>
        /// <returns>A collection of players.</returns>
        [HttpGet("non-admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PlayerReadDTONonAdmin>>> GetPlayersNonAdmin()
        {
            return _mapper.Map<List<PlayerReadDTONonAdmin>>(await _context.Players
                .ToListAsync());
        }


        /// <summary>
        /// Fetches a specific player in the database by a non-admin user. Doesn't display BiteCode and IsPatientZero attributes.
        /// </summary>
        /// <param name="id">The id of the player to fetch.</param>
        /// <returns>The player, if it exists. Otherwise, the NotFound response.</returns>
        [HttpGet("non-admin/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlayerReadDTONonAdmin>> GetPlayerNonAdmin(int id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return _mapper.Map<PlayerReadDTONonAdmin>(player);
        }


        /// <summary>
        /// Helper function, which checks if a player with the given id exists.
        /// </summary>
        /// <param name="id">The id to check for.</param>
        /// <returns>True if a player with that id exists. False otherwise.</returns>
        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
    }
}
