using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkillAssure
{
    internal class Course
    {
        public List<Assessment> Assessments { get; set; } = new List<Assessment>();
        public string CourseId { get; set; }
        public string Name { get; set; }
        public int GetNumberOfMCQBasedAssessments()
        {
            int count = 0;
            foreach (Assessment assessment in Assessments)
            {
                count += assessment.GetNumberOfMCQBasedAssessments();
            }
            return count;
        }
        public int GetNumberOfHandsOnBasedAssessments()
        {
            int count = 0;
            foreach (Assessment assessment in Assessments)
            {
                count += assessment.GetNumberOfHandsOnBasedAssessments();
            }
            return count;
        }
        public int GetNumberOfAssessments()
        {
            return Assessments.Count;
        }
        public int GetTotalMarks()
        {
            int score = 0;
            foreach(Assessment assessment in Assessments)
            {
                score += assessment.GetTotalMarks();
            }
            return score;
        }
    }
}
