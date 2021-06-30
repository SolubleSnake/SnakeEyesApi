using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnakeEyesApi.Models;

namespace SnakeEyesApi.Services
{
    public class SnakeEyesRollService
    {

        static List<SnakeEyesRoll> SnakeEyesRolls { get; }
        static int nextId = 3;
        static SnakeEyesRollService()
        {
            SnakeEyesRolls = new List<SnakeEyesRoll>
            {
                new SnakeEyesRoll { Id = 1, PlayerBalance = 1000, Roll = true, Stake = 1, DiceRoll = "11", IsComplete = true, Dice1 = 1, Dice2 = 1, Winnings = 60 },
                new SnakeEyesRoll { Id = 2, PlayerBalance = 1000, Roll = true, Stake = 1, DiceRoll = "11", IsComplete = true, Dice1 = 1, Dice2 = 1, Winnings = 60 }
            };
        }

        public static List<SnakeEyesRoll> GetAll() => SnakeEyesRolls;
        public static SnakeEyesRoll Get(int id) => SnakeEyesRolls.FirstOrDefault(s => s.Id == id);

        public static void Add(SnakeEyesRoll snakeeyesroll)
        {
            snakeeyesroll.Id = nextId++;
            SnakeEyesRolls.Add(snakeeyesroll);
        }

        public static void Delete(int id)
        {
            var snakeeyesroll = Get(id);
            if (snakeeyesroll is null)
                return;

            SnakeEyesRolls.Remove(snakeeyesroll);
        }
        public static void Update(SnakeEyesRoll snakeeyesroll)
        {
            var index = SnakeEyesRolls.FindIndex(s => s.Id == snakeeyesroll.Id);
            if (index == -1)
                return;

            SnakeEyesRolls[index] = snakeeyesroll;
        }
    }
}
