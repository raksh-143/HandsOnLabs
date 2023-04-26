using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppProblem
{
    class Trainer
    {
        public Organization Organization { get; set; }
        public List<Trainee> Trainees { get; set; }
        public  List<Training> Training { get; set; } = new List<Training>();
    }
}
