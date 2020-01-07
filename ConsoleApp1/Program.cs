using System;
using CreatingTypes;
using CreatingTypes.Task_2;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Newton.FindNthRoot(0.0081, 4, 0.1));
            SortContext sortContext = new SortContext(new SumRows());
            int[,] kek = new int[3, 3] { { 7, 8, 9 }, { 4, 5, 6 }, { 1, 2, 3 } };
            sortContext.ExecuteSort(kek, SortOrder.Decrease);

            sortContext.ContextStrategy = new MaxMinOfRow(TypeSort.Min);
            sortContext.ExecuteSort(kek, SortOrder.Decrease);


        }
    }
}
