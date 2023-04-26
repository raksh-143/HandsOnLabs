using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkillAssure
{
    internal class Iteration
    {
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Assessment> Assessments { get; set; } = new List<Assessment>(); 
        public int IterationNo { get; set; }
        public string Goal { get; set; }
        public int GetNumberOfAssessments()
        {
            int courseAssessmentCount = 0;
            foreach(Course course in Courses)
            {
                courseAssessmentCount += course.GetNumberOfAssessments();
            }
            return Assessments.Count + courseAssessmentCount;
        }
        public int GetNumberOfMCQBasedAssessments()
        {
            int count = 0;
            foreach(Assessment assessment in Assessments)
            {
                count += assessment.GetNumberOfMCQBasedAssessments();
            }
            foreach (Course course in Courses)
            {
                count += course.GetNumberOfMCQBasedAssessments();
            }
            return count;
        }
        public int GetNumberOfHandsOnAssessments()
        {
            int count = 0;
            foreach(Assessment assessment in Assessments)
            {
                count += assessment.GetNumberOfHandsOnBasedAssessments();
            }
            foreach (Course course in Courses)
            {
                count += course.GetNumberOfHandsOnBasedAssessments();
            }
            return count;
        }
        public int GetTotalMarks()
        {
            int totalScore = 0;
            foreach (Assessment assessment in Assessments)
            {
                totalScore += assessment.GetTotalMarks();
            }
            foreach (Course course in Courses)
            {
                totalScore += course.GetTotalMarks();
            }
            return totalScore;
        }
    }
}
