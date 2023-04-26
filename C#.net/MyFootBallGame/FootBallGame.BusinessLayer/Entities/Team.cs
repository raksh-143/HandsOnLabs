using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallGame.BusinessLayer.Entities
{
    public class Team
    {
        public List<Player> TeamPlayers { get; set; } = new List<Player>();
        public TeamStrategy TeamStrategy { get; set; }
        public void SetStrategy() { }
        public void PlayGame() { }
    }
}
