using DailyPractice;
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
        public void TestStart()
        {
            Assert.Pass();
        }

        [Test]
        public void TestParseMultiArray()
        {
            var array = Utility.ParseArray("[[1,2,3],[1,2,3],1,2,3]]", 3);
            var rt = new int[][] { new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 } };
            Assert.AreEqual(rt, array);
        }

        [Test]
        public void TestParseArray()
        {
            var array = Utility.ParseArray("[1,2,3,4,5,6,7,8]");
            var rt = new int[]{ 1,2,3,4,5,6,7,8 };
            Assert.AreEqual(rt, array);
        }
    }
}