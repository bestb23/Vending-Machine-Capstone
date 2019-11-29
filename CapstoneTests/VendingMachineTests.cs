using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        private string testPathToVMInputFile = @"..\..\..\..\Capstone\TextFiles\VendingMachineInputFile.txt";
        private string testPathToLogFile = @"..\..\..\..\Capstone\TextFiles\Log.txt";

        [TestMethod]
        public void TestRecieveMoney0()
        {

            // Arrange
            VendingMachine vendingMachine = new VendingMachine(testPathToVMInputFile, testPathToLogFile);
            // Act
            vendingMachine.ReceiveMoney(0);
            decimal actualResult = vendingMachine.CurrentMoneyProvided;
            // Assert
            Assert.AreEqual(0.00M, actualResult);
        }

        [TestMethod]
        public void TestRecieveMoney5()
        {

            // Arrange
            VendingMachine vendingMachine = new VendingMachine(testPathToVMInputFile, testPathToLogFile);
            // Act
            vendingMachine.ReceiveMoney(5);
            decimal actualResult = vendingMachine.CurrentMoneyProvided;
            // Assert
            Assert.AreEqual(5.00M, actualResult);
        }

        [TestMethod]
        public void TestRecieveMoney1and5()
        {

            // Arrange
            VendingMachine vendingMachine = new VendingMachine(testPathToVMInputFile, testPathToLogFile);
            // Act
            vendingMachine.ReceiveMoney(1);
            vendingMachine.ReceiveMoney(5);
            decimal actualResult = vendingMachine.CurrentMoneyProvided;
            // Assert
            Assert.AreEqual(6.00M, actualResult);
        }

        [TestMethod]
        public void TestRecieveMoneyDoubles()
        {

            // Arrange
            VendingMachine vendingMachine = new VendingMachine(testPathToVMInputFile, testPathToLogFile);
            // Act
            vendingMachine.ReceiveMoney(0.15);
            vendingMachine.ReceiveMoney(2.30);
            decimal actualResult = vendingMachine.CurrentMoneyProvided;
            // Assert
            Assert.AreEqual(2.45M, actualResult);
        }

        [TestMethod]
        public void TestRecieveMoney()
        {

            // Arrange
            VendingMachine vendingMachine = new VendingMachine(testPathToVMInputFile, testPathToLogFile);
            // Act
            vendingMachine.ReceiveMoney(0.05);
            vendingMachine.ReceiveMoney(0.10);
            vendingMachine.ReceiveMoney(0.25);
            vendingMachine.ReceiveMoney(1.00);
            vendingMachine.ReceiveMoney(2.35);
            decimal actualResult = vendingMachine.CurrentMoneyProvided;
            // Assert
            Assert.AreEqual(3.75M, actualResult);
        }

        [TestMethod]
        public void TestAcceptCodeA1()
        {

            // Arrange
            VendingMachine vm = new VendingMachine(testPathToVMInputFile, testPathToLogFile);

            // Act
            vm.ReceiveMoney(1.00);
            string code = "A1";
            vm.AcceptCode(code);
            int actualNumItemsRemain = vm.products[code].NumberItemsRemaining;
            decimal actualCurrentMoneyProvided = vm.CurrentMoneyProvided;

            // Assert
            Assert.AreEqual(4, actualNumItemsRemain);
            Assert.AreEqual(0.50M, actualCurrentMoneyProvided);
        }

        [TestMethod]
        public void TestAcceptCodeB2()
        {

            // Arrange
            VendingMachine vm = new VendingMachine(testPathToVMInputFile, testPathToLogFile);

            // Act
            vm.ReceiveMoney(5.00);
            string code = "B2";
            vm.AcceptCode(code);
            vm.AcceptCode(code);
            vm.AcceptCode(code);
            int actualNumItemsRemain = vm.products[code].NumberItemsRemaining;
            decimal actualCurrentMoneyProvided = vm.CurrentMoneyProvided;

            // Assert
            Assert.AreEqual(2, actualNumItemsRemain);
            Assert.AreEqual(0.50M, actualCurrentMoneyProvided);
        }

        [TestMethod]
        public void TestAcceptCodeC3()
        {

            // Arrange
            VendingMachine vm = new VendingMachine(testPathToVMInputFile, testPathToLogFile);

            // Act
            vm.ReceiveMoney(2.00);
            string code = "C3";
            vm.AcceptCode(code);
            int actualNumItemsRemain = vm.products[code].NumberItemsRemaining;
            decimal actualCurrentMoneyProvided = vm.CurrentMoneyProvided;

            // Assert
            Assert.AreEqual(4, actualNumItemsRemain);
            Assert.AreEqual(1.35M, actualCurrentMoneyProvided);
        }
        [TestMethod]
        public void TestAcceptCodeD4()
        {

            // Arrange
            VendingMachine vm = new VendingMachine(testPathToVMInputFile, testPathToLogFile);

            // Act
            vm.ReceiveMoney(10.00);
            vm.ReceiveMoney(5.00);
            string code = "D4";
            vm.AcceptCode(code);
            vm.AcceptCode(code);
            int actualNumItemsRemain = vm.products[code].NumberItemsRemaining;
            decimal actualCurrentMoneyProvided = vm.CurrentMoneyProvided;

            // Assert
            Assert.AreEqual(3, actualNumItemsRemain);
            Assert.AreEqual(14.50M, actualCurrentMoneyProvided);
        }
        [TestMethod]
        public void TestAcceptCodeMultiplePurchases()
        {

            // Arrange
            VendingMachine vm = new VendingMachine(testPathToVMInputFile, testPathToLogFile);

            // Act
            vm.ReceiveMoney(10.00);
            vm.ReceiveMoney(5.00);
            string codeD4 = "D4";
            string codeA4 = "A4";
            string codeA2 = "A2";
            string codeB1 = "B1";
            string codeC1 = "C1";
            string codeA3 = "A3";
            string codeD1 = "D1";
            string codeB3 = "B3";
            vm.AcceptCode(codeD4);
            vm.AcceptCode(codeA4);
            vm.AcceptCode(codeA2);
            vm.AcceptCode(codeB1);
            vm.AcceptCode(codeC1);
            vm.AcceptCode(codeA3);
            vm.AcceptCode(codeD1);
            vm.AcceptCode(codeB3);
            int actualNumItemsRemainD4 = vm.products[codeD4].NumberItemsRemaining;
            int actualNumItemsRemainA4 = vm.products[codeA4].NumberItemsRemaining;
            int actualNumItemsRemainA2 = vm.products[codeA2].NumberItemsRemaining;
            int actualNumItemsRemainB1 = vm.products[codeB1].NumberItemsRemaining;
            int actualNumItemsRemainC1 = vm.products[codeC1].NumberItemsRemaining;
            int actualNumItemsRemainA3 = vm.products[codeA3].NumberItemsRemaining;
            int actualNumItemsRemainD1 = vm.products[codeD1].NumberItemsRemaining;
            int actualNumItemsRemainB3 = vm.products[codeB3].NumberItemsRemaining;
            decimal actualCurrentMoneyProvided = vm.CurrentMoneyProvided;

            // Assert
            Assert.AreEqual(4, actualNumItemsRemainD4);
            Assert.AreEqual(4, actualNumItemsRemainA4);
            Assert.AreEqual(4, actualNumItemsRemainA2);
            Assert.AreEqual(4, actualNumItemsRemainB1);
            Assert.AreEqual(4, actualNumItemsRemainC1);
            Assert.AreEqual(4, actualNumItemsRemainA3);
            Assert.AreEqual(4, actualNumItemsRemainD1);
            Assert.AreEqual(4, actualNumItemsRemainB3);
            Assert.AreEqual(9.25M, actualCurrentMoneyProvided);
        }


        [TestMethod]
        public void TestLoadMachine()
        {
            
            // Arrange

            // Act

            // Assert

        }

        [DataTestMethod]
        [DataRow(0.00, new int[] { 0, 0, 0 }, DisplayName = "Test 0.00")]
        [DataRow(3.95, new int[] { 15, 2, 0 }, DisplayName = "Test 3.95")]
        [DataRow(5.30, new int[] { 21, 0, 1 }, DisplayName = "Test 5.30")]
        [DataRow(6.65, new int[] { 26, 1, 1 }, DisplayName = "Test 6.65")]
        [DataRow(8.95, new int[] { 35, 2, 0 }, DisplayName = "Test 8.95")]
        [DataRow(20.00, new int[] { 80, 0, 0 }, DisplayName = "Test 20.00")]
        [DataRow(0.05, new int[] { 0, 0, 1 }, DisplayName = "Test 0.05")]
        [DataRow(0.10, new int[] { 0, 1, 0 }, DisplayName = "Test 0.10")]
        [DataRow(0.25, new int[] { 1, 0, 0 }, DisplayName = "Test 0.25")]
        [DataRow(0.15, new int[] { 0, 1, 1 }, DisplayName = "Test 0.15")]
        public void TestFinishTransaction(double change, int[] expectedResult)
        {
            // Arrange
            VendingMachine vendingMachine = new VendingMachine(testPathToVMInputFile, testPathToLogFile);
            vendingMachine.CurrentMoneyProvided = (decimal)change;
            // Act
            Change changeObject = vendingMachine.FinishTransaction();
            int[] actualResult = new int[] { changeObject.Quarters, changeObject.Dimes, changeObject.Nickels };
            // Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);

        }
    }
}
