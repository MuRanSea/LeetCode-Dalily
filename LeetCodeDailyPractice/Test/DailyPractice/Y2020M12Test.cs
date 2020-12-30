using DailyPractice;
using DailyPractice.Y2020.M12;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Y2020M12Test
    {

        [Test]
        public void Test_2020_12_21_0()
        {
            Day_21 foo = new Day_21();
            var array = Utility.ParseArray("[[9,16],[7,13],[9,13],[6,11],[7,10],[0,9],[6,9],[1,8],[7,8],[1,6]]", 2);
            Assert.AreEqual(3, foo.FindMinArrowShots0(array));
        }

        [Test]
        public void Test_2020_12_21_1()
        {
            Day_21 foo = new Day_21();
            var array = Utility.ParseArray("[[9,16],[7,13],[9,13],[6,11],[7,10],[0,9],[6,9],[1,8],[7,8],[1,6]]", 2);
            Assert.AreEqual(3, foo.FindMinArrowShots0(array));
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

        [Test]
        public void Test_28()
        {
            Day_28 foo = new Day_28();
            var rt = foo.MonotoneIncreasingDigits(2350);
            Console.WriteLine(rt);
            Assert.AreEqual(2349, rt);
        }
    }
}
