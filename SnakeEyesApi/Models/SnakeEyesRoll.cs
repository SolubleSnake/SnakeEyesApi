using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeEyesApi.Models
{
    public class SnakeEyesRoll
    {
        public long Id { get; set; }
        public long PlayerBalance { get; set; }
        public bool Roll { get; set; }
        public int Stake { get; set; }
        public string DiceRoll { get; set; }
        public bool IsComplete { get; set; }
        public int Dice1 { get; set; }
        public int Dice2 { get; set; }
        public SnakeEyesRoll()
        {
            this.PlayerBalance = 1000;

        }
    }


}
