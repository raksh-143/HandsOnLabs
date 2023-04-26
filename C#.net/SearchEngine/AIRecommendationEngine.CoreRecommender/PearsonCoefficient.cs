using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationEngine.CoreRecommender
{
    public class PearsonCoefficient : IRecommender
    {
        public double GetCorrelation(List<int> baseData, List<int> otherData)
        {
            //Business Rules
            //Both arrays should be of same length
            //If any value is 0 add 1 to both the array indices (if value is already greatest then add 1 only to the zero value)
            //If other array is smaller than the base array then add 1 to both corresponding indices
            //If base array is smaller than the other array trim the arrays and consider only upto the length of the base array
            if (baseData.Count > otherData.Count)
            {
                BaseCountLarger(baseData, otherData);
            }
            else if(baseData.Count < otherData.Count)
            {
                OtherCountLarger(baseData, otherData);
            }
            CheckForZeroes(baseData, otherData);
            double sumOfX = baseData.Sum();
            double sumOfY = otherData.Sum();
            double sumOfProdOfXY = 0;
            double sumOfSqOfX = 0;
            double sumOfSqOfY = 0;
            Parallel.For(0,baseData.Count,i=>
            {
                sumOfProdOfXY += baseData[i] * otherData[i];
                sumOfSqOfX += baseData[i] * baseData[i];
                sumOfSqOfY += otherData[i] * otherData[i];
            });
            double numerator = (baseData.Count * sumOfProdOfXY - sumOfX * sumOfY);
            double denominator = Math.Sqrt((baseData.Count * sumOfSqOfX - Math.Pow(sumOfX, 2)) * (baseData.Count * sumOfSqOfY - Math.Pow(sumOfY, 2)));
            double r = numerator / denominator;
            return Math.Round(r,4);
        }
        private static void BaseCountLarger(List<int> baseData, List<int> otherData)
        {
            for(int i=otherData.Count; i<baseData.Count; i++)
            {
                otherData.Add(1);
                if (baseData[i] != 10)
                {
                    baseData[i] += 1;
                }
            }
        }
        private static void OtherCountLarger(List<int> baseData, List<int> otherData)
        {
            Parallel.For(baseData.Count, otherData.Count, i =>
            {
                otherData.RemoveAt(i);
            });
        }
        private static void CheckForZeroes(List<int> baseData, List<int> otherData)
        {
            for(int i=0; i < baseData.Count; i++)
            {
                if (baseData[i] == 0)
                {
                    if (otherData[i] != 10)
                    {
                        otherData[i] += 1;
                    }
                    baseData[i] += 1;
                }
                else if (otherData[i] == 0)
                {
                    if (baseData[i] != 10)
                    {
                        baseData[i] += 1;
                    }
                    otherData[i] += 1;
                }
            }
        }
    }
}
