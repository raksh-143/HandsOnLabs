using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallGame.BusinessLayer.Entities
{
    public class Game
    {
        public List<Referee> GameReferees { get; set; } = new List<Referee>();
        public Ball GameBall { get; set; }
        public PlayGround GamePlayGround { get; set; }
        public Team GameForTeam { get; set; }
        public Team GameAgainstTeam { get; set; }
    }
}
