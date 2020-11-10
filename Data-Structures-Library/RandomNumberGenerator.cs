using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Library
{
    /// <summary>
    /// A helper class used for generating random numbers for probabilistic data structures, like SkipList. It contains only one method (Next), and two constructors.
    /// </summary>
    class RandomNumberGenerator
    {
        private long m = 4294967296;
        private const long a = 214013;
        private const long c = 2531011;
        private long min;
        private long max;
        private double seed;

        /// <summary>
        /// A constructor for RandomNumberGenerator class objects, which only sets the seed.
        /// </summary>
        public RandomNumberGenerator()
        {
            seed = DateTime.Now.Ticks % m;
        }

        /// <summary>
        /// A constructor for RandomNumberGenerator class objects, which can be used to generate random numbers that are inside the specified bounds.
        /// </summary>
        /// <param name="min">Lower limit for generating numbers.</param>
        /// <param name="max">Upper limit for generating numbers.</param>
        public RandomNumberGenerator(long min, long max) : this()
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Method that generates random numbers, using a specific formula.
        /// </summary>
        /// <returns>Long (number).</returns>
        public long Next()
        {
            seed = (a * seed + c) % m;
            return (long)((seed / (m - 1)) * (max - min) + min);
        }
    }
}
