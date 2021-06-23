using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeEyesApi.Models
{
    public class SnakeEyesRoll
    {
        public long Id { get; set; }
        public bool Roll { get; set; }
        public bool IsComplete { get; set; }
    }
}
