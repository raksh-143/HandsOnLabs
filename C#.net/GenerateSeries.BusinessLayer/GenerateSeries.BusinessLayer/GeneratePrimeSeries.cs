using System;
using System.Collections.Generic;

namespace GenerateSeries.BusinessLayer
{
    public class GeneratePrimeSeries : IGenerateSeries
    {
        //Questions -> What to do with 1 digit numbers and numbers that have the same number ex:11?

        //Generates the series
        public List<int> Generate(int range)
        {
            List<int> primeNumbers = GeneratePrimeNumbers(range);
            List<int> list = new List<int>();
            List<int> seriesTerms = list;
            int i = 1;
            int j = 0;
            while (j < range)
            {
                seriesTerms.Add(i);
                i = i + primeNumbers[j]; //1+2=3 3+3 =6
                j++;
            }
            return seriesTerms;
        }

        //Generates prime numbers required for generation of the series
        private List<int> GeneratePrimeNumbers(int range)
        {
            int noOfPrimeNumbers = 0;
            int number = 2;
            List<int> listOfPrimeNumbers = new List<int>();
            while (true)
            {
                bool flag = true;
                for (int i = 2; i <= number / 2; i++)
                {
                    if (number % i == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    listOfPrimeNumbers.Add(number);
                    noOfPrimeNumbers++;
                }
                number++;
                if (noOfPrimeNumbers == range)
                {
                    return listOfPrimeNumbers;
                }
            }
        }

        //Gets the count of ascending numbers
        public int GetCountOfAscendingNumbers(List<int> series)
        {
            int count = 0;
            foreach (int number in series)
            {
                if (IsAscending(number))
                {
                    count++;
                }
            }
            return count;
        }

        //Checks if a number is ascending
        private bool IsAscending(int number)
        {
            List<int> digitsInNumber = new List<int>();
            while (number != 0)
            {
                int rem = number % 10;
                number /= 10;
                digitsInNumber.Add(rem);
            }
            if (digitsInNumber.Count < 2) { return false; }
            int[] sortedArray = new int[digitsInNumber.Count];
            int[] nonSortedArray = digitsInNumber.ToArray();
            Array.Reverse(nonSortedArray);
            Array.Copy(digitsInNumber.ToArray(), sortedArray, digitsInNumber.Count);
            Array.Sort(sortedArray);
            for (int i = 0; i < digitsInNumber.Count; i++)
            {
                if (nonSortedArray[i] != sortedArray[i]) //879 789
                {
                    return false;
                }
            }
            return true;
        }

        //Gets the count of descending numbers
        public int GetCountOfDescendingNumbers(List<int> series)
        {
            int count = 0;
            foreach (int number in series)
            {
                if (IsDescending(number))
                {
                    count++;
                }
            }
            return count;
        }

        //Checks if a number is descending
        private bool IsDescending(int number)
        {
            List<int> digitsInNumber = new List<int>();
            while (number != 0)
            {
                int rem = number % 10;
                number /= 10;
                digitsInNumber.Add(rem);
            }
            if (digitsInNumber.Count < 2) { return false; }
            int[] sortedArray = new int[digitsInNumber.Count];
            int[] nonSortedArray = digitsInNumber.ToArray();
            Array.Reverse(nonSortedArray);
            Array.Copy(digitsInNumber.ToArray(), sortedArray, digitsInNumber.Count);
            Array.Sort(sortedArray);
            Array.Reverse(sortedArray);
            for (int i = 0; i < digitsInNumber.Count; i++)
            {
                if (nonSortedArray[i] != sortedArray[i])
                {
                    return false;
                }
            }
            return true;
        }

        //Gets count of neither ascending nor descending numbers
        public int GetCountOfNeitherAscendingNorDescendingNumbers(List<int> series)
        {
            int count = 0;
            foreach (int number in series)
            {
                if (IsNeitherAscendingNorDescending(number))
                {
                    count++;
                }
            }
            return count;
        }

        //Checks if a number is neither ascending nor descending
        private bool IsNeitherAscendingNorDescending(int number)
        {
            if(!IsAscending(number) && !IsDescending(number))
            {
                return true;
            }
            return false;
        }

        //Check if any two digits are adjacent
        public List<int> TwoDigitsAdjacent(List<int> series)
        {
            List<int> resultList = new List<int>();
            foreach(int number in series)
            {
                if (AreTwoDigitsAdjacent(number))
                {
                    resultList.Add(number);
                }
            }
            return resultList;
        }

        private bool AreTwoDigitsAdjacent(int number)
        {
            List<int> digitsInNumber = new List<int>();
            while (number != 0)
            {
                int rem = number % 10;
                number /= 10;
                digitsInNumber.Add(rem);
            }
            for(int i = 0; i < digitsInNumber.Count-1; i++)
            {
                if (digitsInNumber[i] == digitsInNumber[i+1] + 1 || digitsInNumber[i] == digitsInNumber[i+1] - 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
