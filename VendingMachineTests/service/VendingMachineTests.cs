using System.Collections.Generic;
using VendingMachineAssignment.service;
using Xunit;

namespace VendingMachineTests.service
{
    public class VendingMachineTests
    {

        private VendingMachine vendingMachine;

        public VendingMachineTests()
        {
            vendingMachine = new VendingMachine();
        }
        
        [Fact]
        public void InsertMoney()
        {
            vendingMachine.InsertMoney(100);
            vendingMachine.InsertMoney(50);
            vendingMachine.InsertMoney(5);
            vendingMachine.InsertMoney(1);
            vendingMachine.InsertMoney(1);

            Assert.Equal(157, vendingMachine.MoneyPool);
        }


        [Fact]
        public void EndTransaction()
        {
            vendingMachine.InsertMoney(100);
            vendingMachine.InsertMoney(50);
            vendingMachine.InsertMoney(5);
            vendingMachine.InsertMoney(1);
            vendingMachine.InsertMoney(1);

            Dictionary<int, int> coins = vendingMachine.EndTransaction();

            Assert.True(coins.ContainsValue(10));
        }

        [Fact]
        public void test()
        {
            Assert.Equal(0, 2 / 10);
        }
    }
}
