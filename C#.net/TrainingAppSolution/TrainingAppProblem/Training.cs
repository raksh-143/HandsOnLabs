using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppProblem
{
    class Training
    {
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public Trainer Trainer { get; set; }

        public Course Course { get; set; }

        public string GetTrainingOrganizationName()
        {
            return Trainer.Organization.Name;
        }
        public int GetNumberOfTrainees()
        {
            return Trainees.Count;
        }
        public int GetTrainingDurationHours()
        {
            int TrainingDurationHours = 0;
            foreach(Module module in Course.Modules)
            {
                foreach(Unit unit in module.Units)
                {
                    TrainingDurationHours += unit.Duration;
                }
            }
            return TrainingDurationHours;
        }

    }
}
