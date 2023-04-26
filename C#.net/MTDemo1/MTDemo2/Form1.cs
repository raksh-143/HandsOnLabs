using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTDemo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawRedRect(object sender, EventArgs e)
        {
            //Task task = Task.Factory.StartNew(() =>
            //{
            //    //Red Rectangles
            //    Graphics red = panel1.CreateGraphics();
            //    Random rnd = new Random();
            //    for (int i = 1; i <= 1000; i++)
            //    {
            //        int x = rnd.Next(panel1.Width);
            //        int y = rnd.Next(panel1.Height);
            //        red.DrawRectangle(Pens.Red, x, y, 20, 20);
            //        Thread.Sleep(500);
            //    }
            //});
            Stopwatch sw = Stopwatch.StartNew();
            foreach (var file in Directory.GetFiles(@"ImageRotation")){
                Image img = Image.FromFile(file);
                img.RotateFlip(RotateFlipType.Rotate180FlipX);
                FileInfo fileInfo= new FileInfo(file);
                img.Save($"RotatedImages\\{fileInfo.Name}");
            }
            MessageBox.Show($"Done! Took {sw.ElapsedMilliseconds} number of milliseconds");
        }

        private void DrawBlueRect(object sender, EventArgs e)
        {
            //Task task = Task.Factory.StartNew(() =>
            //{
            //    //Red Rectangles
            //    Graphics blue = panel2.CreateGraphics();
            //    Random rnd = new Random();
            //    for (int i = 1; i <= 1000; i++)
            //    {
            //        int x = rnd.Next(panel2.Width);
            //        int y = rnd.Next(panel2.Height);
            //        blue.DrawRectangle(Pens.Blue, x, y, 20, 20);
            //        Thread.Sleep(500);
            //    }
            //});
        }
    }
}
