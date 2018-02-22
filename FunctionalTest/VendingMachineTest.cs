using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalTest
{
    [TestClass]
    public class VendingMachineTest
    {
        //Scenarios
        //1.Inventory :0, Amount: 0 - Result: OUT OF STOCK
        //2.Inventory :1, Amount: 0 - Result: INSUFFICIENT AMT
        //3.Inventory :1, Amount: 50 - Result: CAN Dispensed
        //4.Inventory :3, Amount: 50 - Result: AFTER 2nd Round INSUFFICIENT AMT
        //5.Inventory :5, Amount: 250 - Result: AFTER 5th Round OUT OF STOCK
        //6.Inventory :26, Amount: 1000 - Result: AFTER 25th Round OUT OF STOCK

        [TestMethod]
        public void Test_WorkingConstructor()
        {
            ApolloNorth.VendingMachine vm = new ApolloNorth.VendingMachine(25, 250);
            Assert.AreEqual(vm.NumberOfCan, 25);
            Assert.AreEqual(vm.AccountBalance, 250);
        }

        [TestMethod]
        public void Test_ZeroQuantityInventory_ZeroAmount()
        {
            ApolloNorth.VendingMachine vm = new ApolloNorth.VendingMachine(0, 0);
            var result = vm.BuyDrink();
            Assert.IsTrue(result == "Inventory Out of Stock");

            Assert.AreEqual(result, "Inventory Out of Stock");
        }

        [TestMethod]
        public void Test_InsufficientAmountForPurchase()
        {
            ApolloNorth.VendingMachine vm = new ApolloNorth.VendingMachine(1, 0);
            var result = vm.BuyDrink();
            Assert.IsTrue(result == "Insufficient fund in Account");
        }

        [TestMethod]
        public void Test_SuccessfulPurchase()
        {
            ApolloNorth.VendingMachine vm = new ApolloNorth.VendingMachine(1, 50);
            var result = vm.BuyDrink();
            Assert.IsTrue(result.Contains("CAN Dispensed"));            
         }


        [TestMethod]
        public void Test_Pin_Valid()
        {
            ApolloNorth.VendingMachine vm = new ApolloNorth.VendingMachine();
            vm.SuppliedPin = "01234";
            var result = vm.ValidatePin();
            Assert.IsTrue(result == "OK");
        }

        [TestMethod]
        public void Test_Pin_Invalid()
        {
            ApolloNorth.VendingMachine vm = new ApolloNorth.VendingMachine();
            vm.SuppliedPin = "145";
            var result = vm.ValidatePin();
            Assert.IsFalse(result == "Invalid Card Pin");
        }

        [TestMethod]
        public void Test_Inventory_Balance_Total()
        {
            ApolloNorth.VendingMachine vm = new ApolloNorth.VendingMachine(25,250);            
            var result = vm.ToString();
            Assert.AreEqual(result, "Total Inventory: 25      Account Amount: 250p");
        }


    }
}
