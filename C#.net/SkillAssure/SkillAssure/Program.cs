using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillAssure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SkillAssureTrainingModel model = new SkillAssureTrainingModel();

            Iteration iteration1 = new Iteration();
            Iteration iteration2 = new Iteration();

            model.Iterations[0] = iteration1;
            model.Iterations[1] = iteration2;

            //When a new course is created make sure the assessment count is at least one if not throw an exception
            //Because minimum one assessment has to be there
            Course course1 = new Course();
            Course course2 = new Course();

            iteration1.Courses.Add(course1);
            iteration2.Courses.Add(course2);

            Assessment assessment1 = new Assessment();
            Assessment assessment2 = new Assessment();

            course1.Assessments.Add(assessment1);
            iteration1.Assessments.Add(assessment2);

            Question question1 = new MCQQuestion();
            Question question2 = new MCQQuestion();
            Question question3 = new MCQQuestion();
            Question question4 = new MCQQuestion();
            Question question5 = new MCQQuestion();
            question1.Marks = 1;
            question2.Marks = 1;
            question3.Marks = 1;
            question4.Marks = 1;
            question5.Marks = 1;

            Question question6 = new HandsOnQuestion();
            Question question7 = new HandsOnQuestion();
            question6.Marks = 5;
            question7.Marks = 5;

            assessment1.Questions.Add(question1);
            assessment1.Questions.Add(question2);
            assessment1.Questions.Add(question3);
            assessment1.Questions.Add(question4);
            assessment1.Questions.Add(question5);

            assessment2.Questions.Add(question6);          
            assessment2.Questions.Add(question7);

            Console.WriteLine($"Number of assessments in training = {model.GetTotalAssessmentsInTheTraining()}");
            Console.WriteLine($"Number of MCQ Based assessments = {model.GetNumMCQBasedAssessments()}");
            Console.WriteLine($"Number of HandsOn Based asssessments = {model.GetNumHandsOnBasedAssessments()}");
            Console.WriteLine($"Total score of all assessments = {model.GetTotalScoreOfAllAssessments()}");
            Console.ReadKey();
        }
    }
}
