using System;
using System.Collections.Generic;
using System.Text;

namespace CreatingTypes
{
    public class SortContext
    {
        public IStrategy ContextStrategy { private get; set; }

        public SortContext(IStrategy strategy)
        {
            ContextStrategy = strategy;
        }

        public void ExecuteSort(int [,] array, SortOrder sortOrder)
        {
            ContextStrategy.Sort(array, sortOrder);
        }
    }
}
