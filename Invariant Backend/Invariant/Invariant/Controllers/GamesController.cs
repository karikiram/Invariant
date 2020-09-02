using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Invariant.Models;
using AutoMapper;

namespace Invariant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public GamesController(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Games/GetGames
        [HttpGet("GetGames")]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetGameDto()
        {
            var games = await _context.Game.ToListAsync();
            var gameDtos = _mapper.Map<List<GameDto>>(games);
            return gameDtos;
        }

        // GET: api/Games/CountGames
        [HttpGet("CountGames")]
        public int GetGameCount()
        {
            var games = _context.Game.ToList();
            var gameDtos = _mapper.Map<List<GameDto>>(games);
            var gameCount = gameDtos.Count();
            return gameCount;
        }

		// GET: api/Games/5
		//[HttpGet("{id}")]
		//public async Task<ActionResult<GameDto>> GetGameDto(int id)
		//{
		//	var gameDto = await _context.Game.FindAsync(id);


		//	if (gameDto == null)
		//	{
		//		return NotFound();
		//	}

		//	return gameDto;
		//}

		// PUT: api/Games/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		[HttpPut("{id}")]
        public async Task<IActionResult> PutGameDto(int id, GameDto gameDto)
        {
            if (id != gameDto.GameId)
            {
                return BadRequest();
            }

            _context.Entry(gameDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameDtoExists(id))
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

        // POST: api/Games/PostNewGame
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("PostNewGame")]
        public async Task<ActionResult<GameDto>> PostGameDto(GameDto gameDto)
        {
            var game = new Game
            {
                GameName = gameDto.GameName,
                GameDescription = gameDto.GameDescription
            };
            _context.Game.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameDto", new { id = gameDto.GameId }, gameDto);
        }

        // DELETE: api/Games/5
        [HttpDelete("DeleteGame/{id}")]
        public async Task<ActionResult<GameDto>> DeleteGameDto(int id)
        {
            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Game.Remove(game);
            await _context.SaveChangesAsync();

            return new GameDto();
        }

        private bool GameDtoExists(int id)
        {
            return _context.Game.Any(e => e.GameId == id);
        }
    }
}
