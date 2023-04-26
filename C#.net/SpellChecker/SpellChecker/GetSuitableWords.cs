using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker
{
    public static class GetSuitableWords
    {

        public static List<string> GetWords(string misspelt)
        {
            StreamReader reader  = new StreamReader("Dictionary.txt");
            string data = reader.ReadToEnd();
            string[] words = data.Split('\n');
            Dictionary<string,int> wordStrength = new Dictionary<string,int>();
            ConcurrentDictionary<string,int> wordStrength2 = new ConcurrentDictionary<string,int>();
            Parallel.ForEach(words, word =>
            {
                string actualWord = word.Trim();
                if (actualWord.StartsWith(misspelt) && actualWord != misspelt)
                {
                    int value = LevenshteinDistance(misspelt, actualWord);
                    wordStrength2[actualWord] = value;
                }
            });
            wordStrength = wordStrength2.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            List<string> ProbableWords = new List<string>();
            int i = 1;
            foreach(string key in wordStrength.Keys)
            {
                if (i == 11)
                {
                    break;
                }
                ProbableWords.Add(key);
                i++;
            }
            return ProbableWords;
        }

        public static int LevenshteinDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
    }
}
