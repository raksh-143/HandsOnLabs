using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallGame.BusinessLayer.Entities
{
    public class Decorator:Player
    {
        public Player CurrentPlayer { get; set; }
        public override void PassBall()
        {
            throw new NotImplementedException();
        }
        public void AssignPlayer()
        {

        }
    }
}
