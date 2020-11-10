using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Library
{
    class RandomNumberGenerator
    {
        private long m = 4294967296;
        private const long a = 214013;
        private const long c = 2531011;
        private long min;
        private long max;
        private double seed;


        public RandomNumberGenerator()
        {
            seed = DateTime.Now.Ticks % m;
        }

        public RandomNumberGenerator(long min, long max) : this()
        {
            this.min = min;
            this.max = max;
        }

        public long Next()
        {
            seed = (a * seed + c) % m;
            return (long)((seed / (m - 1)) * (max - min) + min);
        }
    }
}
