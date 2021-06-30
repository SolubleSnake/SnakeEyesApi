using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnakeEyesApi.Models;
using System.Text;

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

        //public SnakeEyesRollsController()
        //{

        //}

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
        [HttpPost]
        
        public async Task<ActionResult<SnakeEyesRoll>> PostSnakeEyesRoll(SnakeEyesRoll snakeEyesRoll, long id)
        {

            await GetRandomNumbers();
            var stringTask = client.GetStringAsync("https://www.random.org/integers/?num=2&min=1&max=6&col=2&base=10&format=plain");

            var msg = await stringTask;
            string cleaned = msg.Replace("\n", "").Replace("\t", "");
            char[] numbers = cleaned.ToCharArray();
            int[] numbersInt = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbersInt[i] = Convert.ToInt32(numbers[i].ToString());
            }

            int dice1 = numbersInt[0];
            int dice2 = numbersInt[1];
            //long PlayerBalance = snakeEyesRoll.PlayerBalance;
            string DiceRoll = cleaned.ToString();
            int stake = snakeEyesRoll.Stake;


            if (IsSnakeEyes(dice1, dice2))
            {
                snakeEyesRoll.PlayerBalance = snakeEyesRoll.PlayerBalance + stake * 30;
                snakeEyesRoll.DiceRoll = cleaned.ToString();
                snakeEyesRoll.Dice1 = dice1;
                snakeEyesRoll.Dice2 = dice2;
                snakeEyesRoll.Winnings = stake * 30;
            }

            else if (IsPair(dice1, dice2))
            {
                snakeEyesRoll.PlayerBalance = snakeEyesRoll.PlayerBalance + stake * 7;
                snakeEyesRoll.DiceRoll = cleaned.ToString();
                snakeEyesRoll.Dice1 = dice1;
                snakeEyesRoll.Dice2 = dice2;
                snakeEyesRoll.Winnings = stake * 7;

            }
            else
            {
                snakeEyesRoll.PlayerBalance = snakeEyesRoll.PlayerBalance - stake;
                snakeEyesRoll.DiceRoll = cleaned.ToString();
                snakeEyesRoll.Dice1 = dice1;
                snakeEyesRoll.Dice2 = dice2;
            }

            _context.SnakeEyesRolls.Add(snakeEyesRoll);

            await _context.SaveChangesAsync();

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

        private static readonly HttpClient client = new HttpClient();

        public static async Task GetRandomNumbers()
        {

            string stringTask = await client.GetStringAsync("https://www.random.org/integers/?num=2&min=1&max=6&col=2&base=10&format=plain");

        }

        public bool IsSnakeEyes(int dice1, int dice2)
        {
            if (dice1.Equals(dice2) && dice1.Equals(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsPair(int dice1, int dice2)
        {
            if(dice1.Equals(dice2) && !dice1.Equals(1))
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }

    }

    internal record NewRecord(object Id);
}
