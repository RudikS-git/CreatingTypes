using System;
using System.Collections.Generic;
using System.Text;

namespace CreatingTypes
{
    public interface IStrategy
    {
        void Sort(int[,] array, SortOrder sortOrder);
    }
}
