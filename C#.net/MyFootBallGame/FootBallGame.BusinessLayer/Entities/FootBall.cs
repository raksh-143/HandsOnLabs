using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallGame.BusinessLayer.Entities
{
    public class FootBall:Ball
    {
        private FootBall() { }
        public static readonly FootBall FootBallInstance = new FootBall();
    }
}
