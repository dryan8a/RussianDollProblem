using System;
using System.Collections.Generic;

namespace RussianDollProblem
{
    public static class EnvelopeFuncs
    {
        public static int EfficientEnvelopeCount((int length,int width)[] envelopes)
        {
            if(envelopes.Length <= 1)
            {
                return envelopes.Length;
            }

            for (int i = envelopes.Length - 1; i > 0; i--) //Sorts from lowest to Highest by length
            {
                for (int j = 0; j < i; j++)
                {
                    if (envelopes[j].length > envelopes[j + 1].length || (envelopes[j].length == envelopes[j + 1].length && envelopes[j].width > envelopes[j + 1].width))
                    {
                        var temp = envelopes[j];
                        envelopes[j] = envelopes[j + 1];
                        envelopes[j + 1] = temp;
                    }
                }
            }

            int currentMaxCount = 1;
            var envelopeMaxCount = new int[envelopes.Length]; //corresponds to the max count that can fit in the envelope at i (including itself)
            for(int i = 0;i<envelopes.Length;i++)
            {
                envelopeMaxCount[i] = 1; //every envelope has a minimum count of 1

                for(int j = 0;j<i;j++)
                {
                    if(envelopes[i].length > envelopes[j].length && envelopes[i].width > envelopes[j].width && envelopeMaxCount[i] <= envelopeMaxCount[j])
                    {
                        envelopeMaxCount[i] = envelopeMaxCount[j] + 1;
                    }
                }

                currentMaxCount = currentMaxCount > envelopeMaxCount[i] ? currentMaxCount : envelopeMaxCount[i];
            }

            return currentMaxCount;
        }

        /// <summary>
        /// Please don't use. Fundamentally broken...
        /// </summary>
        /// <param name="envelopes"></param>
        /// <returns></returns>
        public static int BrokenEnvelopeCount((int length, int width)[] envelopes)
        {
            if (envelopes.Length == 0) return 0;

            SortByLength(envelopes);
            int stackedEnvelopesByLength = CountEnvelopesInOrder(envelopes);

            if (stackedEnvelopesByLength == envelopes.Length) return stackedEnvelopesByLength;

            SortByWidth(envelopes);
            int stackedEnvelopesByWidth = CountEnvelopesInOrder(envelopes);

            return stackedEnvelopesByLength > stackedEnvelopesByWidth ? stackedEnvelopesByLength : stackedEnvelopesByWidth;
        }

        private static int CountEnvelopesInOrder((int length, int width)[] envelopes)
        {
            int stackedEnvelopes = 1;
            int currentTopEnvelope = 0;
            for (int i = 1; i < envelopes.Length; i++)
            {
                if (envelopes[currentTopEnvelope].length > envelopes[i].length && envelopes[currentTopEnvelope].width > envelopes[i].width)
                {
                    stackedEnvelopes++;
                    currentTopEnvelope = i;
                }
            }
            return stackedEnvelopes;
        }

        public static void SortByLength((int length, int width)[] envelopes)
        {
            for (int i = envelopes.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (envelopes[j].length < envelopes[j + 1].length || (envelopes[j].length == envelopes[j + 1].length && envelopes[j].width < envelopes[j+1].width))
                    {
                        var temp = envelopes[j];
                        envelopes[j] = envelopes[j + 1];
                        envelopes[j + 1] = temp;
                    }
                }
            }
        }

        public static void SortByWidth((int length, int width)[] envelopes)
        {
            for (int i = envelopes.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (envelopes[j].width < envelopes[j + 1].width || (envelopes[j].width == envelopes[j + 1].width && envelopes[j].length < envelopes[j+1].length))
                    {
                        var temp = envelopes[j];
                        envelopes[j] = envelopes[j + 1];
                        envelopes[j + 1] = temp;
                    }
                }
            }
        }
    }
}
