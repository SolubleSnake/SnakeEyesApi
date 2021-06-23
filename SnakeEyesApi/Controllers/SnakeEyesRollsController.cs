using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnakeEyesApi.Models;

namespace SnakeEyesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnakeEyesRollsController : ControllerBase
    {
        private readonly SnakeEyesContext _context;

        public SnakeEyesRollsController(SnakeEyesContext context)
        {
            _context = context;
        }

        // GET: api/SnakeEyesRolls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SnakeEyesRoll>>> GetSnakeEyesRolls()
        {
            return await _context.SnakeEyesRolls.ToListAsync();
        }

        // GET: api/SnakeEyesRolls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SnakeEyesRoll>> GetSnakeEyesRoll(long id)
        {
            var snakeEyesRoll = await _context.SnakeEyesRolls.FindAsync(id);

            if (snakeEyesRoll == null)
            {
                return NotFound();
            }

            return snakeEyesRoll;
        }

        // PUT: api/SnakeEyesRolls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSnakeEyesRoll(long id, SnakeEyesRoll snakeEyesRoll)
        {
            if (id != snakeEyesRoll.Id)
            {
                return BadRequest();
            }

            _context.Entry(snakeEyesRoll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SnakeEyesRollExists(id))
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

        // POST: api/SnakeEyesRolls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SnakeEyesRoll>> PostSnakeEyesRoll(SnakeEyesRoll snakeEyesRoll)
        {
            _context.SnakeEyesRolls.Add(snakeEyesRoll);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetSnakeEyesRoll", new { id = snakeeyesroll.Id }, snakeeyesroll);
            return CreatedAtAction(nameof(GetSnakeEyesRoll), new { id = snakeEyesRoll.Id }, snakeEyesRoll);
        }

        // DELETE: api/SnakeEyesRolls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSnakeEyesRoll(long id)
        {
            var snakeEyesRoll = await _context.SnakeEyesRolls.FindAsync(id);
            if (snakeEyesRoll == null)
            {
                return NotFound();
            }

            _context.SnakeEyesRolls.Remove(snakeEyesRoll);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SnakeEyesRollExists(long id)
        {
            return _context.SnakeEyesRolls.Any(e => e.Id == id);
        }
    }

    internal record NewRecord(object Id);
}
