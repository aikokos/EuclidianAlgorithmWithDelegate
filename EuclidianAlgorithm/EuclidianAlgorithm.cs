// <copyright file="EuclidianAlgorithm.cs" company="LearningCompany">
// Copyright (c) Company. All rights reserved.
// </copyright>
namespace EuclidianAlgorithm
{
    using System;
    delegate int operation(int a, int b);

    /// <summary>
    /// The class implementing standard Euclidian and Stein algorithm.
    /// It can be used to find GCD (Greatest Common Divisor).
    /// </summary>
    public static class EuclidianAlgorithm
    {
        /// <summary>
        /// Method for getting GCD of two numbers.
        /// </summary>
        /// <param name="number1">first number</param>
        /// <param name="number2">second number</param>
        /// <returns>Returns the GCD of two numbers.</returns>
        public static int GetGCDforTwoNumbers(int number1, int number2)
        {
            int a = Math.Abs(number1), b = Math.Abs(number2);
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }      
            }

            return a;
        }

        /// <summary>
        /// Method for getting GCD of several numbers.
        /// </summary>
        /// <param name="pararray">array of numbers</param>
        /// <param name="elapsedMs1">time spent to get GCD</param>
        /// <returns>Returns the GCD of numbers in array.</returns>
        public static int GetGCDforSeveralNumbers(int[] pararray, out long elapsedMs1)
        {
            //// begin timer
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = pararray[0];
            for (int i = 1; i < pararray.Length; i++)
            {
                gcd = GetGCDforTwoNumbers(gcd, pararray[i]);
            }

            elapsedMs1 = watch.ElapsedMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Method for getting GCD of two numbers with the use of Stein algorithm.
        /// </summary>
        /// <param name="u1">first number</param>
        /// <param name="v1">second number</param>
        /// <returns>Returns the GCD of two numbers.</returns>
        public static int GetSteinGcd(int u1, int v1)
        {
            int u = Math.Abs(u1);
            int v = Math.Abs(v1);
            //// simple cases (termination)
            if (u == v)
            {
                return u;
            }

            if (u == 0)
            {
                return v;
            }

            if (v == 0)
            {
                return u;
            }

            // Finding K, where K is the greatest  
            // power of 2 that divides both u and v 
            int k;
            for (k = 0; ((u | v) & 1) == 0; ++k)
            {
                u >>= 1;
                v >>= 1;
            }

            // Dividing a by 2 until a becomes odd 
            while ((u & 1) == 0)
            {
                u >>= 1;
            }

            // From here on, 'u' is always odd 
            do
            {
                // If v is even, remove  
                // all factor of 2 in v  
                while ((v & 1) == 0)
                {
                    v >>= 1;
                }

                /* Now u and v are both odd. Swap  
                if necessary so u <= v, then set  
                v = v - u (which is even).*/
                if (u > v)
                {
                    // Swap u and v. 
                    int temp = u;
                    u = v;
                    v = temp;
                }

                v = v - u;
            }
            while (v != 0);
            /* restore common factors of 2 */
            return u << k;
        }

        /// <summary>
        /// Method for getting GCD of several numbers using Stein algorithm.
        /// </summary>
        /// <param name="pararray">array of numbers</param>
        /// <param name="elapsedMs1">time spent to get GCD</param>
        /// <returns>Returns the GCD of numbers in array.</returns>
        public static int GetSteinGCDforSeveralNumbers(int[] pararray, out long elapsedMs1)
        {
            //// begin timer
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            operation = GetSteinGcd;
            int gcd = pararray[0];
            for (int i = 1; i < pararray.Length; i++)
            {
                gcd = operation(gcd, pararray[i]);
            }

            elapsedMs1 = watch.ElapsedMilliseconds;
            return gcd;
        }
    }
}
