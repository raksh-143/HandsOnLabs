using System.Collections.Generic;

namespace GenerateSeries.BusinessLayer
{
    public interface IGenerateSeries
    {
        List<int> Generate(int range);
        int GetCountOfAscendingNumbers(List<int> series); //123
        int GetCountOfDescendingNumbers(List<int> series); //987
        int GetCountOfNeitherAscendingNorDescendingNumbers(List<int> series);//687
        List<int> TwoDigitsAdjacent(List<int> series);
    }
}
