using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]

    public class ChangeTests
    {
        [DataTestMethod]
        [DataRow(1.00, new int[] { 4, 0, 0 }, DisplayName = "Test 1.00")]
        [DataRow(3.95, new int[] { 15, 2, 0 }, DisplayName = "Test 3.95")]
        [DataRow(5.30, new int[] { 21, 0, 1 }, DisplayName = "Test 5.30")]
        [DataRow(6.65, new int[] { 26, 1, 1 }, DisplayName = "Test 6.65")]
        [DataRow(8.95, new int[] { 35, 2, 0 }, DisplayName = "Test 8.95")]
        [DataRow(20.00, new int[] { 80, 0, 0 }, DisplayName = "Test 20.00")]
        [DataRow(0.05, new int[] { 0, 0, 1 }, DisplayName = "Test 0.05")]
        [DataRow(0.10, new int[] { 0, 1, 0 }, DisplayName = "Test 0.10")]
        [DataRow(0.25, new int[] { 1, 0, 0 }, DisplayName = "Test 0.25")]
        [DataRow(0.15, new int[] { 0, 1, 1 }, DisplayName = "Test 0.15")]
        public void TestCalculateChange(double change, int[] expectedResult)
        {
            // Arrange
            Change changeObject = new Change(change);

            // Act
            int[] actualResult = new int[] { changeObject.Quarters, changeObject.Dimes, changeObject.Nickels };

            // Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
           
        }

    }
}
