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

        [Fact]
        public void SnakeEyesApi_IsSnakeEyesPair()
        {
            var snakeEyesRollsController = new SnakeEyesRollsController();
            bool result = snakeEyesRollsController.IsPair(2, 2);

            Assert.True(result, "I am a pair");
        }

        [Fact]
        public void SnakeEyesApi_IsSnakeEyes()
        {
            var snakeEyesRollsController = new SnakeEyesRollsController();
            bool result = snakeEyesRollsController.IsSnakeEyes(1, 1);

            Assert.True(result, "I am Snake Eyes");
        }
    }
}
