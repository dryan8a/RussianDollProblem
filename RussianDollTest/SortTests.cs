using RussianDollProblem;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;


namespace RussianDollTest
{
    public class SortTests
    {
        [Theory]
        [ClassData(typeof(LengthSortData))]
        public void SortByLengthTest((int,int)[] sorted, (int,int)[] unsorted)
        {
            Assert.Equal(sorted.Length, unsorted.Length);
            EnvelopeFuncs.SortByLength(unsorted);
            for(int i = 0;i < sorted.Length;i++)
            {
                Assert.Equal(sorted[i].Item1, unsorted[i].Item1);
                Assert.Equal(sorted[i].Item2, unsorted[i].Item2);
            }
        }

        [Theory]
        [ClassData(typeof(WidthSortData))]
        public void SortByWidthTest((int, int)[] sorted, (int, int)[] unsorted)
        {
            Assert.Equal(sorted.Length, unsorted.Length);
            EnvelopeFuncs.SortByWidth(unsorted);
            for (int i = 0; i < sorted.Length; i++)
            {
                Assert.Equal(sorted[i].Item1, unsorted[i].Item1);
                Assert.Equal(sorted[i].Item2, unsorted[i].Item2);
            }
        }
    }

    public class LengthSortData : IEnumerable<object[]>
    {
        private List<object[]> data = new List<object[]>
        {
            new object[]{ new [] {(7,8), (5, 6), (3, 4), (1, 2)}, new[] { (1, 2), (5, 6), (3, 4), (7, 8) } },
            new object[]{ new [] {(1, 2)}, new[] {(1, 2)} },
            new object[]{ new [] { (51, 50), (50, 50), (49, 50), (49, 49), (49, 48) }, new[] { (50, 50), (49, 49), (49,50), (49,48), (51, 50) } },
            new object[]{ new [] {(100,100), (50, 50), (50, 49), (1, 1)}, new[] { (1, 1), (100, 100), (50, 49), (50, 50) } },
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class WidthSortData : IEnumerable<object[]>
    {
        private List<object[]> data = new List<object[]>
        {
            new object[]{ new [] {(7,8), (5, 6), (3, 4), (1, 2)}, new[] { (1, 2), (5, 6), (3, 4), (7, 8) } },
            new object[]{ new [] {(1, 2)}, new[] {(1, 2)} },
            new object[]{ new [] { (51, 50), (50, 50), (49, 50), (49, 49),  (49, 48) }, new[] { (50, 50), (49, 49), (49, 50),  (49, 48), (51, 50) } },
            new object[]{ new [] { (100, 100), (50, 50), (49, 50), (1, 1) }, new[] { (1, 1), (100, 100), (49, 50), (50, 50) } }
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
