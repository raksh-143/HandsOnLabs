using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillAssure
{
    internal class SkillAssureTrainingModel
    {
        public string ClientName { get; set; }
        public Iteration[] Iterations = new Iteration[3]; 
        public int GetTotalAssessmentsInTheTraining()
        {
            int totalNumberOfAssessments=0;
            foreach(Iteration iteration in Iterations)
            {
                if(iteration != null)
                {
                    totalNumberOfAssessments += iteration.GetNumberOfAssessments();
                }
            }
            return totalNumberOfAssessments;
        }
        public int GetNumMCQBasedAssessments()
        {
            int totalNumberMCQBasedOfAssessments = 0;
            foreach (Iteration iteration in Iterations)
            {
                if(iteration != null)
                {
                    totalNumberMCQBasedOfAssessments += iteration.GetNumberOfMCQBasedAssessments();
                }
            }
            return totalNumberMCQBasedOfAssessments;
        }
        public int GetNumHandsOnBasedAssessments()
        {
            int totalNumberHandsOnBasedOfAssessments = 0;
            foreach (Iteration iteration in Iterations)
            {
                if(iteration != null)
                {
                    totalNumberHandsOnBasedOfAssessments += iteration.GetNumberOfHandsOnAssessments();
                }
            }
            return totalNumberHandsOnBasedOfAssessments;
        }
        public int GetTotalScoreOfAllAssessments()
        {
            int totalScore = 0;
            foreach (Iteration iteration in Iterations)
            {
                if(iteration != null)
                {
                    totalScore += iteration.GetTotalMarks();
                }
            }
            return totalScore;
        }
    }
}
