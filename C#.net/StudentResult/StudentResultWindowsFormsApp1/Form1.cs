using StudentResult.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentResultWindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentName = textBox4.Text;
            double subject1 = int.Parse(textBox1.Text);
            double subject2 = int.Parse(textBox2.Text);
            double subject3 = int.Parse(textBox3.Text);
            double[] scores = { subject1, subject2, subject3 };
            Grade studentData = new Grade(scores);
            double sumOfScores = studentData.GetSum();
            double averageOfScores = studentData.GetAverage();
            string grade = studentData.GetGrade();
            MessageBox.Show($"{studentName} has scored {sumOfScores} marks in 3 subjects and has achieved an average of {averageOfScores}. {grade}");
        }
    }
}
