using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Organization and give a name to it
            Organization organization = new Organization { Name = "Pratian" };

            //Create a trainer and set their organization
            Trainer trainer = new Trainer();
            trainer.Organization = organization;

            //Create a training and set the trainer
            Training training = new Training();
            training.Trainer = trainer;

            //Display the training organization name
            Console.WriteLine($"Training Organization Name is {training.GetTrainingOrganizationName()}");

            //Add trainees to training
            Trainee t1 = new Trainee();
            Trainee t2 = new Trainee();
            Trainee t3 = new Trainee();
            training.Trainees.Add(t1);
            training.Trainees.Add(t2);
            training.Trainees.Add(t3);

            //Display the number of trainees
            Console.WriteLine($"Number of trainees is {training.GetNumberOfTrainees()}");

            //Create Course
            Course course = new Course();

            //Creates Modules
            Module mod1 = new Module();
            Module mod2 = new Module();

            //Create Units for Modules
            Unit mod1Unit1 = new Unit { Duration = 3 };
            Unit mod1Unit2 = new Unit { Duration = 5 };
            Unit mod2Unit1 = new Unit { Duration = 4 };
            Unit mod2Unit2 = new Unit { Duration = 3 };

            //Add Units to Modules
            mod1.Units.Add(mod1Unit1);
            mod1.Units.Add(mod1Unit2);
            mod2.Units.Add(mod2Unit1);
            mod2.Units.Add(mod2Unit2);

            //Add Modules to Course
            course.Modules.Add(mod1);
            course.Modules.Add(mod2);

            //Add Course to Training
            training.Course = course;

            Module mod3 = new Module();
            course.Modules.Add(mod3);
            Unit mod3unit1 = new Unit { Duration = 8 };
            mod3.Units.Add(mod3unit1);

            //Display the number of training hours
            Console.WriteLine($"Total Course Duration is {training.GetTrainingDurationHours()}");

            Console.ReadKey();
        }
    }
}
