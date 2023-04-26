using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppProblem
{
    class Organization
    {
        public string Name { get; set; }
        public List<Trainer> Trainers { get;set; } = new List<Trainer>();
    }
}
