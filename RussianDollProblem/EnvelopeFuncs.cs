﻿using System;
using System.Collections.Generic;

namespace RussianDollProblem
{
    public static class EnvelopeFuncs
    {
        public static int EfficientEnvelopeCount((int length,int width)[] envelopes)
        {
            throw new NotImplementedException();
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
