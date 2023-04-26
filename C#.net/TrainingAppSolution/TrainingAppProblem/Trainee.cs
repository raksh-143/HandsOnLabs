using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppProblem
{
    class Trainee
    {
        public Trainer Trainer { get; set; }

        public List<Training> Training { get; set; } = new List<Training>();
    }
}
