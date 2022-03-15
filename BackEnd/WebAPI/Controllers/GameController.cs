using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.Admin;
using WebAPI.Models.DTO.Game;

namespace WebAPI.Controllers
{
    /// <summary>
    /// The controller holds all the API endpoints for the Games table
    /// </summary>
    [Route("api/game")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly HumanVZombiesDbContext _context;
        private readonly IMapper _mapper;
        private readonly User _currentUser;

        /// <summary>
        /// Adding context and mapper with dependency injection.
        /// </summary>
        /// <param name="context">The proper context</param>
        /// <param name="mapper">The automapper</param>
        public GameController(HumanVZombiesDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = _context.User.First(u => u.UserName == httpContextAccessor.HttpContext.User.Identity.Name);
        }


        /// <summary>
        /// This is a test method to test ci/cd.
        /// </summary>
        /// <returns>The specified game</returns>
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GameReadDTO>>> FindGame(string name)
        {
            return _mapper.Map<List<GameReadDTO>>(await _context.Games
                .FirstOrDefaultAsync((g) => name == g.Name));
        }

        /// <summary>
        /// Fetches all games from the database.
        /// </summary>
        /// <returns>A collection of games.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GameReadDTO>>> GetGames()
        {
            return _mapper.Map<List<GameReadDTO>>(await _context.Games
                .ToListAsync());
        }

        /// <summary>
        /// Fetches a specific game in the database.
        /// </summary>
        /// <param name="id">The id of the game to fetch.</param>
        /// <returns>The game, if it exists. Otherwise, the NotFound response.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GameReadDTO>> GetGame(int id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return _mapper.Map<GameReadDTO>(game);
        }

        /// <summary>
        /// Creates a new game based on the given game object.
        /// </summary>
        /// <param name="dtoGame">The game object.</param>
        /// <returns>The newly created game.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Game>> PostGame(GameCreateDTO dtoGame)
        {
            Game domainGame = _mapper.Map<Game>(dtoGame);

            //Making an admin directly
            var dtoAdmin = new AdminCreateDTO { User = _currentUser.Id };
            Admin domainAdmin = _mapper.Map<Admin>(dtoAdmin);
            _context.Admin.Add(domainAdmin);
            await _context.SaveChangesAsync();

            domainGame.Admin = domainAdmin;
            domainGame.AdminId = domainAdmin.Id;

            _context.Games.Add(domainGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGame", new { id = domainGame.Id },
                                   _mapper.Map<GameReadDTO>(domainGame));
        }

        /// <summary>
        /// Updates a specific game with the values of the given game object.
        /// </summary>
        /// <param name="id">The id of the game to update.</param>
        /// <param name="dtoGame">A game object containing the updated values.</param>
        /// <returns>Nothing if the update succeeds. BadRequest if the given id doesn't match the id of a game. NotFound if the game doesn't exist.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutGame(int id, GameUpdateDTO dtoGame)
        {
            if (id != dtoGame.Id)
            {
                return BadRequest();
            }

            Game domainGame = _mapper.Map<Game>(dtoGame);

            _context.Entry(domainGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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
        /// Helper function, which checks if a game with the given id exists.
        /// </summary>
        /// <param name="id">The id to check for.</param>
        /// <returns>True if a game with that id exists. False otherwise.</returns>
        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
