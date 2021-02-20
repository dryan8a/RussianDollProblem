using RussianDollProblem;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;


namespace RussianDollTest
{
    public class EnvelopeCountTests
    {
        [Theory]
        [ClassData(typeof(CountData))]
        public void BrokenEnvelopeCountTest(int actualCount, (int, int)[] envelopes)
        {
            int resultCount = EnvelopeFuncs.BrokenEnvelopeCount(envelopes);
            Assert.Equal(actualCount, resultCount);
        }

        [Theory]
        [ClassData(typeof(CountData))]
        public void EfficientEnvelopeCountTest(int actualCount, (int, int)[] envelopes)
        {
            int resultCount = EnvelopeFuncs.EfficientEnvelopeCount(envelopes);
            Assert.Equal(actualCount, resultCount);
        }
    }

    public class CountData : IEnumerable<object[]>
    {
        private readonly List<object[]> data = new List<object[]>
        {
            new object[] {3, new [] {(50,50),(25,50),(20,18),(15,5)}},
            new object[] {2 ,new [] {(50,50),(40,20),(30,30)}},
            new object[] {3 ,new [] {(60,60),(20,50),(30,10),(5,5)}},
            new object[] {4, new [] {(60,60),(50,50),(40,30),(20,20)}},
            new object[] {6, new [] {(50,50),(45,55),(43,52),(42,51),(25,50),(20,18),(15,5)}},
            new object[] {3, new [] {(50,20),(45,125),(25,48),(22,44),(4,124)}},
            new object[] {1, new [] {(10,5),(10,6),(10,7),(10,7),(11,5)}},
            new object[] {0, new (int,int)[0]},
            new object[] {1, new [] {(5,5)}}
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
