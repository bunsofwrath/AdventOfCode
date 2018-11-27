using System;
using AdventOfCode_2015_25;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void Previous_With11_ExpectArgumentOutOfRangeException()
        {
            //arrange

            //act-assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Grid.Previous((1, 1)));
        }

        [TestMethod]
        public void Previous_With21_Expect11()
        {
            //arrange

            //act
            var coordinate = Grid.Previous(2, 1);

            //assert
            Assert.AreEqual(new Coordinate(1, 1), coordinate);
        }

        [TestMethod]
        public void Previous_WithMultipleCoordinates_ExpectCorrectPreviousCoordinates()
        {
            //arrange

            //act-assert
            Assert.AreEqual(new Coordinate(1, 1), Grid.Previous(2, 1));
            Assert.AreEqual(new Coordinate(2, 1), Grid.Previous(1, 2));
            Assert.AreEqual(new Coordinate(1, 2), Grid.Previous(3, 1));
            Assert.AreEqual(new Coordinate(3, 1), Grid.Previous(2, 2));
            Assert.AreEqual(new Coordinate(2, 2), Grid.Previous(1, 3));
            Assert.AreEqual(new Coordinate(1, 3), Grid.Previous(4, 1));
        }

        [TestMethod]
        public void At_WithMultipleCoordinates_ExpectCorrectValues()
        {
            //arrange
            var grid = new Grid();

            //act-assert
            Assert.AreEqual(20151125, grid.At(1, 1));
            Assert.AreEqual(31916031, grid.At(2, 1));
            Assert.AreEqual(18749137, grid.At(1, 2));
            Assert.AreEqual(16080970, grid.At(3, 1));
            Assert.AreEqual(21629792, grid.At(2, 2));
            Assert.AreEqual(17289845, grid.At(1, 3));
            Assert.AreEqual(24592653, grid.At(4, 1));
            Assert.AreEqual(8057251 , grid.At(3, 2));
            Assert.AreEqual(16929656, grid.At(2, 3));
            Assert.AreEqual(30943339, grid.At(1, 4));
            Assert.AreEqual(77061   , grid.At(5, 1));
            Assert.AreEqual(32451966, grid.At(4, 2));
            Assert.AreEqual(1601130 , grid.At(3, 3));
            Assert.AreEqual(7726640 , grid.At(2, 4));
            Assert.AreEqual(10071777, grid.At(1, 5));
            Assert.AreEqual(33071741, grid.At(6, 1));
            Assert.AreEqual(17552253, grid.At(5, 2));
        }
    }
}
