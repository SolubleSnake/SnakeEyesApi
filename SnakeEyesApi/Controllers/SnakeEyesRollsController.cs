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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        
        public async Task<ActionResult<SnakeEyesRoll>> PostSnakeEyesRoll(SnakeEyesRoll snakeEyesRoll, long id)
        {

            //var snakeEyesRoll = await _context.SnakeEyesRolls.FindAsync(id);
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

            //IsPair(dice1, dice2);

            //IsPairOrSnakeEyes(dice1, dice2, DiceRoll, stake, PlayerBalance);

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
            //_context.SnakeEyesRolls.Add(snakeEyesRoll);
            //int dice1 = numbersInt[0];
            //int dice2 = numbersInt[1];
            //long PlayerBalance = snakeEyesRoll.PlayerBalance;
            //string DiceRoll = cleaned.ToString();

            //(int, int, string, int, long) IsPairOrSnakeEyes(int dice1, int dice2, string DiceRoll, int stake, long PlayerBalance)
            //{


            //    if (dice1 == dice2 && dice1 == 1)
            //    {
            //        snakeEyesRoll.PlayerBalance = 1000 + stake * 30;
            //        snakeEyesRoll.Dice1 = dice1;
            //        snakeEyesRoll.Dice2 = dice2;
            //        snakeEyesRoll.DiceRoll = DiceRoll;
            //    }

            //    else if (dice1 == dice2)
            //    {
            //        snakeEyesRoll.PlayerBalance = 1000 + stake * 7;
            //        snakeEyesRoll.Dice1 = dice1;
            //        snakeEyesRoll.Dice2 = dice2;
            //        snakeEyesRoll.DiceRoll = DiceRoll;
            //    }
            //    else if (PlayerBalance == 1000)
            //    {
            //        msg = msg.Replace(@"\", "");
            //        msg = msg.Replace("t", "");
            //        msg = msg.Remove('1', '2');
            //        string parsedMsg = msg.Remove('4', '2');
            //        string parsedMsg = msg.Replace("n", "");
            //        var aStringBuilder = new StringBuilder(msg);
            //        aStringBuilder.Remove('1', '2');
            //        aStringBuilder.Remove('4', '2');
            //        string parsedMsg = aStringBuilder.ToString();

            //        snakeEyesRoll.PlayerBalance. = 1000 - stake;
            //        snakeEyesRoll.Dice1 = dice1;
            //        snakeEyesRoll.Dice2 = dice2;
            //        snakeEyesRoll.DiceRoll = DiceRoll;

            //    }

            //    return (snakeEyesRoll.Dice1, snakeEyesRoll.Dice2, snakeEyesRoll.DiceRoll, stake, snakeEyesRoll.PlayerBalance);
            //}
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
                //msg = msg.Replace(@"\", "");
                //msg = msg.Replace("t", "");
                //msg = msg.Remove('1', '2');
                //string parsedMsg = msg.Remove('4', '2');
                //string parsedMsg = msg.Replace("n", "");
                //var aStringBuilder = new StringBuilder(msg);
                //aStringBuilder.Remove('1', '2');
                //aStringBuilder.Remove('4', '2');
                //string parsedMsg = aStringBuilder.ToString();

                snakeEyesRoll.PlayerBalance = snakeEyesRoll.PlayerBalance - stake;
                snakeEyesRoll.DiceRoll = cleaned.ToString();

                snakeEyesRoll.Dice1 = dice1;
                snakeEyesRoll.Dice2 = dice2;
            }

            _context.SnakeEyesRolls.Add(snakeEyesRoll);


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

        public static async Task GetRandomNumbers()
        {
            //client.DefaultRequestHeaders.Accept.Clear();
            ////client.DefaultRequestHeaders.Accept.Add(
            ////    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            string stringTask = await client.GetStringAsync("https://www.random.org/integers/?num=2&min=1&max=6&col=2&base=10&format=plain");

            //var msg = await stringTask;
            //string cleaned = msg.Replace("\n", "").Replace("\t", "");
            //char[] numbers = cleaned.ToCharArray();
            //int[] numbersInt = new int[numbers.Length];
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    numbersInt[i] = Convert.ToInt32(numbers[i].ToString());
            //}

            //int dice1 = numbersInt[0];
            //int dice2 = numbersInt[1];


            //Console.Write(msg);
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

        //(int, int, string, int, long) public IsPairOrSnakeEyes(int dice1, int dice2, string DiceRoll, int stake, long PlayerBalance)
        //{


        //    if (dice1 == dice2 && dice1 == 1)
        //    {
        //        PlayerBalance = 1000 + stake * 30;
        //        //dice1 = dice1;
        //        //dice2 = dice2;
        //        //DiceRoll = DiceRoll;
        //    }

        //    else if (dice1 == dice2)
        //    {
        //        PlayerBalance = 1000 + stake * 7;
        //        //dice1 = dice1;
        //        //dice2 = dice2;
        //        //DiceRoll = DiceRoll;
        //    }
        //    else if (PlayerBalance == 1000)
        //    {
        //        //msg = msg.Replace(@"\", "");
        //        //msg = msg.Replace("t", "");
        //        //msg = msg.Remove('1', '2');
        //        //string parsedMsg = msg.Remove('4', '2');
        //        //string parsedMsg = msg.Replace("n", "");
        //        //var aStringBuilder = new StringBuilder(msg);
        //        //aStringBuilder.Remove('1', '2');
        //        //aStringBuilder.Remove('4', '2');
        //        //string parsedMsg = aStringBuilder.ToString();

        //        PlayerBalance = 1000 - stake;
        //        //dice1 = dice1;
        //        //dice2 = dice2;
        //        //DiceRoll = DiceRoll;

        //    }

        //    return (dice1, dice2, DiceRoll, stake, PlayerBalance);
        //}

        //private long SetPlayerBalance(long id)
        //{
        //    return _context.SnakeEyesRolls.Add PlayerBalance = 1000;
        //}
    }

    internal record NewRecord(object Id);
}
