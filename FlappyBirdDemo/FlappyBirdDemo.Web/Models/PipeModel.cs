using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlappyBirdDemo.Web.Models
{
    public class PipeModel
    {
        public int DistanceFromLeft { get; private set; } = 500;
        public int DistanceFromBottom { get; private set; } = new Random().Next(0, 60);
        public int Speed { get; private set; } = 2;
        public void Move()
        {
            DistanceFromLeft -= Speed;
        }
    }
}
