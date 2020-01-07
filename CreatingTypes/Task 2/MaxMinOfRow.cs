using System;
using CreatingTypes.Task_2;


namespace CreatingTypes
{
    public class MaxMinOfRow:IStrategy
    {
        public Func<int, int, bool> FunctypeSort;
        public Func<int, int, bool> funcOrderSort;

        public MaxMinOfRow(TypeSort typeSort)
        {
            if (TypeSort.Min == typeSort)
            {
                FunctypeSort = (value, min) => { return value < min; };
            }
            else
            {
                FunctypeSort = (value, max) => { return value > max; };
            }
        }

        public void Sort(int[,] array, SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Decrease)
            {
                funcOrderSort = (numFirst, numSecond) => { return numFirst < numSecond; };
            }
            else
            {
                funcOrderSort = (numFirst, numSecond) => { return numFirst > numSecond; };
            }

            int length;
            int[] elementRows = GetElementRowsArray(array, out length);

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (funcOrderSort(elementRows[i], elementRows[j]))
                    {
                        ArrayHelper.SwapRows(array, i, j, length);
                        ArrayHelper.SwapValues(ref elementRows[i], ref elementRows[j]);
                    }
                }
            }

        }

        private int[] GetElementRowsArray(int[,] array, out int length)
        {
            length = array.GetLength(0);

            int[] tempArray = new int[length];

            for(int i = 0; i<length; i++)
            {
                int max = array[i, 0];
                for (int j = 1; j<length; j++)
                {
                    if(FunctypeSort(array[i, j], max))
                    {
                        max = array[i, j];
                    }
                }
                tempArray[i] = max;
            }
            return tempArray;
        }
    }
}
