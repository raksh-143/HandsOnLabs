using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillAssure
{
    internal class Assessment
    {
        public List<Question> Questions { get; set; } = new List<Question>();
        public int AssessmentId { get; set; }
        public string Desc { get; set; }
        public int NoQuestions { get; set; }
        public DateTime DtAssessment { get; set; }
        public int GetNumberOfMCQBasedAssessments()
        {
            Question question = Questions[0];
            if(question is MCQQuestion)
            {
                return 1;
            }
            return 0;
        }
        public int GetNumberOfHandsOnBasedAssessments()
        {
            Question question = Questions[0];
            if (question is HandsOnQuestion)
            {
                return 1;
            }
            return 0;
        }
        public int GetTotalMarks()
        {
            int totalScore = 0;
            foreach (Question question in Questions)
            {
                totalScore += question.Marks;
            }
            return totalScore;
        }
    }
}
