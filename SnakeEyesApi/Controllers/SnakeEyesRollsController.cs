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
        
        public async Task<ActionResult<SnakeEyesRoll>> PostSnakeEyesRoll(SnakeEyesRoll snakeEyesRoll, long id)
        {

            //var snakeEyesRoll = await _context.SnakeEyesRolls.FindAsync(id);
            await ProcessRandomNumbers();
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

            //var aStringBuilder = new StringBuilder(msg);
            //aStringBuilder.Remove('1', '2');
            //aStringBuilder.Remove('3', '2');
            //int indexOf1 = msg.IndexOf(@"\");
            //int indexOf2 = msg.IndexOf("t");
            //int indexOf3 = msg.IndexOf("n");
            //msg = msg.Replace(@"\", "");
            //msg = msg.Replace("t", "");
            //msg = msg.Replace("n", "");
            ////msg = msg.Remove(indexOf1, 2);
            ////msg = msg.Remove(indexOf2, 2);
            //string parsedMessage = msg.Remove(indexOf3, 1);
            //msg = aStringBuilder.ToString();
            ////char[] numbersAsChar = msg.ToCharArray();
            ////char[] numbers = numbersAsChar.Trim(@"\");
            ////char[] charsToTrim = { '*', ' ', '\'' };
            ////string[] numbers = msg.Trim(charsToTrim);
           _context.SnakeEyesRolls.Add(snakeEyesRoll);

            if (dice1 == dice2 && dice1 == 1)
            {
                snakeEyesRoll.PlayerBalance = 1030;
                snakeEyesRoll.DiceRoll = cleaned.ToString();
                snakeEyesRoll.Dice1 = dice1;
                snakeEyesRoll.Dice2 = dice2;
            }

            else if (dice1 == dice2)
            {
                snakeEyesRoll.PlayerBalance = 1007;
                snakeEyesRoll.DiceRoll = cleaned.ToString();
                snakeEyesRoll.Dice1 = dice1;
                snakeEyesRoll.Dice2 = dice2;
            }
            else if (snakeEyesRoll.PlayerBalance == 1000)
            {
                //msg = msg.Replace(@"\", "");
                //msg = msg.Replace("t", "");
                //msg = msg.Remove('1', '2');
                //string parsedMsg = msg.Remove('4', '2');
                //string parsedMsg = msg.Replace("n", "");
                //var aStringBuilder = new StringBuilder(msg);
                //aStringBuilder.Remove('1', '2');
                //aStringBuilder.Remove('4', '2');
                //string parsedMsg = aStringBuilder.ToString();

                    snakeEyesRoll.PlayerBalance = 1001;
                    snakeEyesRoll.DiceRoll = cleaned.ToString();

                    snakeEyesRoll.Dice1 = dice1;
                    snakeEyesRoll.Dice2 = dice2;
            }



            //var msg = await stringTask;



            //if (snakeEyesRoll.Roll == true)
            //{
            //    snakeEyesRoll.DiceRoll = msg;
            //}






            await _context.SaveChangesAsync();
            //SetPlayerBalance(1);
            //if (snakeEyesRoll.PlayerBalance == 1000)
            //{
            //    snakeEyesRoll.PlayerBalance = 1001;
            //        };

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

        private bool SnakeEyesPreviousRoll(long id)
        {
            return _context.SnakeEyesRolls.Any(e => e.Id == id -1);
        }

        private static readonly HttpClient client = new HttpClient();

        public static async Task ProcessRandomNumbers()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("https://www.random.org/integers/?num=2&min=1&max=6&col=2&base=10&format=plain");

            var msg = await stringTask;

            
            //Console.Write(msg);
        }

        //private long SetPlayerBalance(long id)
        //{
        //    return _context.SnakeEyesRolls.Add PlayerBalance = 1000;
        //}
    }

    internal record NewRecord(object Id);
}
