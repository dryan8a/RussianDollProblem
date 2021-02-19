using RussianDollProblem;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;


namespace RussianDollTest
{
    public class UnitTest1
    {
        [Theory]
        [ClassData(typeof(Data))]
        public void BrokenEnvelopeCountTest(int actualCount, (int, int)[] envelopes)
        {
            int resultCount = RussianDollEnvelope.BrokenEnvelopeCount(envelopes);
            Assert.Equal(actualCount, resultCount);
        }
    }

    public class Data : IEnumerable<object[]>
    {
        private readonly List<object[]> data = new List<object[]>
        {
            new object[] {3, new [] {(50,50),(25,50),(20,18),(15,5)}},
            new object[] {2 ,new [] {(50,50),(40,20),(30,30)}},
            new object[] {3 ,new [] {(60,60),(20,50),(30,10),(5,5)}},
            new object[] {4, new [] {(60,60),(50,50),(40,30),(20,20)}},
            new object[] {6, new [] {(50,50),(45,55),(43,52),(42,51),(25,50),(20,18),(15,5)}},
            new object[] {3, new [] {(50,20),(45,125),(25,48),(22,44),(4,124)}},
            new object[] {1, new [] {(10,5),(10,6),(10,7),(11,7)}}
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
