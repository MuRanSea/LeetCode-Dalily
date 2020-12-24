using DailyPractice.Y2020.M12;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Test()
        {
            Assert.Pass();
        }

        [Test]
        public void Test_2020_12_22()
        {
            Day_22 foo = new Day_22();
            int[][] parameter1 = new int[][]
            {
                new int[]{1,2},new int[]{2,3},new int[]{3,4},new int[]{1,3}
            };
            int[][] parameter2 = new int[][]
            {
                new int[]{1,2},new int[]{2,3},new int[]{2,3},new int[]{2,3}
            };
            var rt1 = foo.EraseOverlapIntervals(parameter1);
            var rt2 = foo.EraseOverlapIntervals(parameter2);
            Assert.AreEqual(1, rt1);
            Assert.AreEqual(2, rt2);
        }

        [Test]
        public void Test_2020_12_23()
        {
            Day_23 foo = new Day_23();
            string str = "ababcbacadefegdehijhklij";
            IList<int> result = new List<int>() { 9, 7, 8 };
            Assert.AreEqual(result, foo.PartitionLabels(str));
        }

        [Test]
        public void Test_2020_12_24()
        {
            Day_24 foo = new Day_24();
            var parameter = new int[][]
            {
                new int[]{1,4},
                new int[]{2,3}
            };

            var result = new int[][]
            {
                new int[]{1,4}
            };
            Assert.AreEqual(result, foo.Merge(parameter));
        }
    }
}