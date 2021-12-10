using AoC2021Class.Day09;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC2021Test.Day09
{
    [TestClass]
    public class BasinSizeTest
    {
        private int[,] testMap = { };

        [TestInitialize]
        public void Setup()
        {
            var stringMap = new List<string>
            {
                "2199943210",
                "3987894921",
                "9856789892",
                "8767896789",
                "9899965678",
            };
            testMap = MapUtility.ConvertInputStringListTo2DArray(stringMap);
        }

        [TestMethod]
        public void Top_left_basin()
        {
            // act
            var actual = MapUtility.BasinSize(testMap, 0, 1);
            // assert
            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void Middle_basin()
        {
            // act
            var actual = MapUtility.BasinSize(testMap, 2, 2);
            // assert
            Assert.AreEqual(14, actual);
        }

        [TestMethod]
        public void Top_right_basin()
        {
            // act
            var actual = MapUtility.BasinSize(testMap, 0, 9);
            // assert
            Assert.AreEqual(9, actual);
        }

        [TestMethod]
        public void Bottom_right_basin()
        {
            // act
            var actual = MapUtility.BasinSize(testMap, 4, 6);
            // assert
            Assert.AreEqual(9, actual);
        }

    }
}