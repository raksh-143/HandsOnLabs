using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingWordsInASentence
{
    internal class CountWordsInASentence
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the sentence: ");
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            Dictionary<string,int> wordCount = new Dictionary<string,int>();
            foreach(string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount.Add(word, 1);
                }
            }
            foreach(string word in wordCount.Keys)
            {
                Console.WriteLine($"{word}->{wordCount[word]}");
            }
            Console.ReadKey();
        }
    }
}
