using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SnakeEyesApi.Controllers;


namespace SnakeEyesApi.Tests
{
    public class SnakeEyesApi_IsSnakeEyesPairShould
    {

        [Theory]
        [InlineData(1, 1)][InlineData(1, 2)]
        [InlineData(1, 3)]
        [InlineData(1, 4)]
        [InlineData(1, 5)]
        [InlineData(1, 6)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        [InlineData(2, 3)]
        [InlineData(2, 4)]
        [InlineData(2, 5)]
        [InlineData(2, 6)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(3, 4)]
        [InlineData(3, 5)]
        [InlineData(3, 6)]
        [InlineData(4, 1)]
        [InlineData(4, 2)]
        [InlineData(4, 3)]
        [InlineData(4, 4)]
        [InlineData(4, 5)]
        [InlineData(4, 6)]
        [InlineData(5, 1)]
        [InlineData(5, 2)]
        [InlineData(5, 3)]
        [InlineData(5, 4)]
        [InlineData(5, 5)]
        [InlineData(5, 6)]
        [InlineData(6, 1)]
        [InlineData(6, 2)]
        [InlineData(6, 3)]
        [InlineData(6, 4)]
        [InlineData(6, 5)]
        [InlineData(6, 6)]
        public void SnakeEyesApi_IsSnakeEyesPair(int value1, int value2)
        {
            var snakeEyesRollsController = new SnakeEyesRollsController();
            bool result = snakeEyesRollsController.IsPair(value1, value2);

            Assert.True(result, $"{value1}, and {value2} are not a pair");
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        [InlineData(1, 4)]
        [InlineData(1, 5)]
        [InlineData(1, 6)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        [InlineData(2, 3)]
        [InlineData(2, 4)]
        [InlineData(2, 5)]
        [InlineData(2, 6)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(3, 4)]
        [InlineData(3, 5)]
        [InlineData(3, 6)]
        [InlineData(4, 1)]
        [InlineData(4, 2)]
        [InlineData(4, 3)]
        [InlineData(4, 4)]
        [InlineData(4, 5)]
        [InlineData(4, 6)]
        [InlineData(5, 1)]
        [InlineData(5, 2)]
        [InlineData(5, 3)]
        [InlineData(5, 4)]
        [InlineData(5, 5)]
        [InlineData(5, 6)]
        [InlineData(6, 1)]
        [InlineData(6, 2)]
        [InlineData(6, 3)]
        [InlineData(6, 4)]
        [InlineData(6, 5)]
        [InlineData(6, 6)]
        public void SnakeEyesApi_IsSnakeEyes(int value1, int value2)
        {
            var snakeEyesRollsController = new SnakeEyesRollsController();
            bool result = snakeEyesRollsController.IsSnakeEyes(value1, value2);

            Assert.True(result, $"{value1} and  {value2} are Snake Eyes");
        }

        [Fact]
        public async Task SnakeEyesApi_IsCorrectMessage()
        {
            //var snakeEyesRollsController = new SnakeEyesRollsController();
            string result = SnakeEyesRollsController.GetRandomNumbers().ToString();
            Assert.Contains("\n", result);
        }
    }
}
