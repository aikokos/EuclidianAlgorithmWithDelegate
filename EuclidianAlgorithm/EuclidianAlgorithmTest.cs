// <copyright file="EuclidianAlgorithmTest.cs" company="LearningCompany">
// Copyright (c) Company. All rights reserved.
// </copyright>
namespace EuclidianAlgorithm
{
    using NUnit.Framework;

    /// <summary>
    /// Tests for class EuclidianAlgorithm.
    /// </summary>
    public class EuclidianAlgorithmTest
    {
        /// <summary>
        /// Method for testing GetGCDforSeveralNumbers.
        /// </summary>
        /// <param name="pararray">array of numbers</param>
        /// <returns>Returns the GCD of numbers in array.</returns>
        [Test]
        [TestCase(new int[] { 12, 16, 20, 24 }, ExpectedResult = 4)]
        [TestCase(new int[] { 12, 0, 20, 24 }, ExpectedResult = 4)]
        [TestCase(new int[] { 3, 9, 27 }, ExpectedResult = 3)]
        [TestCase(new int[] { 2, 3, 4 }, ExpectedResult = 1)]
        public int GetGCDforSeveralNumbersTest(int[] pararray)
        {
            long elapsedMs1;
            return EuclidianAlgorithm.GetGCDforSeveralNumbers(pararray, out elapsedMs1);
        }

        /// <summary>
        /// Method for testing GetSteinGCDforSeveralNumbers.
        /// </summary>
        /// <param name="pararray">array of numbers</param>
        /// <returns>Returns the GCD of numbers in array.</returns>
        [Test]
        [TestCase(new int[] { 12, 16, 20, 24 }, ExpectedResult = 4)]
        [TestCase(new int[] { 12, 0, 20, 24 }, ExpectedResult = 4)]
        [TestCase(new int[] { 3, 9, 27 }, ExpectedResult = 3)]
        [TestCase(new int[] { 2, 3, 4 }, ExpectedResult = 1)]
        public int GetSteinGCDforSeveralNumbersTest(int[] pararray)
        {
            long elapsedMs1;
            return EuclidianAlgorithm.GetSteinGCDforSeveralNumbers(pararray, out elapsedMs1);
        }
    }
}