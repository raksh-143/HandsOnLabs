using AIRecommendationEngine.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIRecommendationEngine.Common.Entities;
using System.Diagnostics;

namespace AIRecommendation.TestingEntities
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            CSVDataLoader dl = new CSVDataLoader();
            BookDetails bd = dl.Load();
            Console.WriteLine(bd.Books[7658].ISBN);
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
