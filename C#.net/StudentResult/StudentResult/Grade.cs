using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentResult.Business
{
    public class Grade
    {
        double sum=0, average;
        string grade;
        double[] scores;

        public Grade(double[] scores)
        {
            this.scores = scores;
        }
        public double GetSum()
        {
            for(int i = 0; i < scores.Length; i++)
            {
                sum += scores[i];
            }
            return sum;
        }
        public double GetAverage()
        {
            Grade StudentAverage = new Grade(scores);
            sum = StudentAverage.GetSum();
            average = sum / 3;
            return average;
        }
        public string GetGrade()
        {
            Grade StudentGrade = new Grade(scores);
            average = StudentGrade.GetAverage();
            if (average >= 60)
            {
                return "Student has secured 1st class";
            }
            else if(average >= 50)
            {
                return "Student has secured 2nd class";
            }
            else if(average >= 35)
            {
                return "Student has secured pass class";
            }
            else
            {
                return "Student has failed";
            }
        }
    }
}
