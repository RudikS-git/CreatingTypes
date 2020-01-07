using System;
using NUnit.Framework;
using CreatingTypes;
using CreatingTypes.Task_2;
using System.Collections;
using System.Collections.Generic;

namespace CreatingTypesTests
{
    public class Tests
    {
        static public IEnumerable<TestCaseData> combination_tests()
        {
            yield return new TestCaseData(new int[,] { { 6, 2, 2 }, { 2, 10, 1 }, { 7, 3, 9 } },
                                          new MaxMinOfRow(TypeSort.Min),
                                          SortOrder.Decrease,
                                          new int[,] { { 7, 3, 9 }, { 6, 2, 2 }, { 2, 10, 1 } }).SetName("test 1"); ;

            yield return new TestCaseData(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } },
                                            new MaxMinOfRow(TypeSort.Max),
                                            SortOrder.Increase,
                                            new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }).SetName("test 2"); ;

            yield return new TestCaseData(new int[,] { { 2, 2, 8 }, { 1, 3, 7 }, { 0, 0, 5 } },
                                          new SumRows(),
                                          SortOrder.Increase,
                                          new int[,] { { 0, 0, 5 }, { 1, 3, 7 }, { 2, 2, 8 } }).SetName("test 3");

            yield return new TestCaseData(new int[,] { { 9, 2, 8 }, { 1, 3, 7 }, { 0, 0, 5 } },
                                          new SumRows(),
                                          SortOrder.Decrease,
                                          new int[,] { { 9, 2, 8 }, { 1, 3, 7 }, { 0, 0, 5 } }).SetName("test 4");

            yield return new TestCaseData(new int[,] { { 9, 4, 4 }, { 3, 12, 0 }, { 8, 2, 10 } },
                                          new MaxMinOfRow(TypeSort.Min),
                                          SortOrder.Decrease,
                                          new int[,] { { 9, 4, 4 }, { 8, 2, 10 }, { 3, 12, 0 } }).SetName("test 5"); ;
        }

        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double FindNthRoot_Test(double number, int degree, double precision)
        {
            return Newton.FindNthRoot(number, degree, precision);
        }

        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void FindNthRoot_Degree_Precision_ArgumentOutOfRangeException(double number, int degree, double precision) => 
            Assert.Throws<ArgumentException>(() => 
                CreatingTypes.Newton.FindNthRoot(number, degree, precision));


        [TestCaseSource("combination_tests")]
        public void Sort_Tests(int [,] array, IStrategy strategy, SortOrder sortOrder, int[,] expectedArray)
        {
            SortContext sortContext = new SortContext(strategy);
            sortContext.ExecuteSort(array, sortOrder);
            Assert.AreEqual(array, expectedArray);
        }
    }
}