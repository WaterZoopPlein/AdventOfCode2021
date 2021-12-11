using AoC2021Core;
using AoC2021Class.Day09;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC2021Test.Day09
{
    [TestClass]
    public class CheckLowPointTest
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
            testMap = ReadInput.ConvertInputStringListTo2DArray(stringMap);
        }

        [TestMethod]
        public void North_border_low_point()
        {
            // act
            var actual = MapUtility.LowPointCheck(testMap, 0, 1);

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void South_border_low_point()
        {
            // act
            var actual = MapUtility.LowPointCheck(testMap, 4, 6);

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Internal_low_point()
        {
            // act
            var actual = MapUtility.LowPointCheck(testMap, 2, 2);

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Internal_non_low_point()
        {
            // act
            var actual = MapUtility.LowPointCheck(testMap, 3, 3);

            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void West_border_non_low_point()
        {
            // act
            var actual = MapUtility.LowPointCheck(testMap, 3, 0);

            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void East_border_non_low_point()
        {
            // act
            var actual = MapUtility.LowPointCheck(testMap, 3, 9);

            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Corner_low_point()
        {
            // act
            var actual = MapUtility.LowPointCheck(testMap, 0, 9);

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Corner_non_low_point()
        {
            // act
            var actual = MapUtility.LowPointCheck(testMap, 4, 9);

            // assert
            Assert.IsFalse(actual);
        }
    }
}