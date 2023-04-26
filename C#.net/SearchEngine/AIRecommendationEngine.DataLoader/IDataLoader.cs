using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecommendationEngine.Common.Entities;

namespace RecommendationEngine.DataLoader
{
    public interface IDataLoader
    {
        BookDetails Load();
    }
}
