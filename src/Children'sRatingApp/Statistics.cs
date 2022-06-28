using System;
using System.Collections.Generic;

namespace Children_sRatingApp
{
    public class Statistics
    { 
        public double High;
        public double Low;
        public double Sum;
        public double Count;

        public Statistics()
        {
            Count = 0;
            Sum = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(Low, number);
            High = Math.Max(High, number);
        }
    }
}