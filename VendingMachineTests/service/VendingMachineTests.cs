using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachineAssignment.Exceptions;
using VendingMachineAssignment.model;
using VendingMachineAssignment.repository;
using VendingMachineAssignment.service;
using Xunit;

namespace VendingMachineTests.service
{
    public class VendingMachineTests
    {

        private readonly VendingMachine vendingMachine;
        private readonly ProductRepository productRepository;

        public VendingMachineTests()
        {
            List<Product> products = new List<Product>()
            {
                new Juice(8, "Orange Juice", "Orange Flavor"),
                new CandyBar(12, "Chocolate bar", "Chocolate Flavor"),
                new Lobster(128, "Lobster", "Chocolate Flavor")
            };
            productRepository = new ProductRepository(products);
            vendingMachine = new VendingMachine(productRepository);
        }
        
        [Fact]
        public void InsertMoney()
        {
            vendingMachine.InsertMoney(1000);
            vendingMachine.InsertMoney(500);
            vendingMachine.InsertMoney(100);
            vendingMachine.InsertMoney(100);
            vendingMachine.InsertMoney(50);
            vendingMachine.InsertMoney(20);
            vendingMachine.InsertMoney(5);
            vendingMachine.InsertMoney(1);
            vendingMachine.InsertMoney(1);
            vendingMachine.InsertMoney(1);

            Assert.Equal(1778, vendingMachine.MoneyPool);
        }

        [Fact(DisplayName = "Not a valid denomination, throws ArgumentException")]
        public void InsertMoneynotValidAmount()
        {
            var exception = Assert.Throws<ArgumentException>(() => vendingMachine.InsertMoney(49));

            Assert.Equal("Not a valid money input", exception.Message);
        }


        [Fact (DisplayName = "End transaction retunrns a dictionary with coins")]
        public void EndTransaction()
        {
            vendingMachine.InsertMoney(100);
            vendingMachine.InsertMoney(100);
            vendingMachine.InsertMoney(100);
            vendingMachine.InsertMoney(50);
            vendingMachine.InsertMoney(5);
            vendingMachine.InsertMoney(1);
            vendingMachine.InsertMoney(1);
            vendingMachine.InsertMoney(1);
            vendingMachine.InsertMoney(1);

            Dictionary<int, int> coins = vendingMachine.EndTransaction();

            Assert.Equal(3, coins.FirstOrDefault(coins => coins.Key == 100).Value);
            Assert.Equal(1, coins.FirstOrDefault(coins => coins.Key == 50).Value);
            Assert.Equal(1, coins.FirstOrDefault(coins => coins.Key == 5).Value);
            Assert.Equal(4, coins.FirstOrDefault(coins => coins.Key == 1).Value);
            Assert.True(vendingMachine.MoneyPool == 0);
        }

        [Fact(DisplayName = "End transaction with empty money pool. returns 0")]
        public void EndTransactionMoneyPoolEmpty()
        {
            vendingMachine.EndTransaction();

            Assert.True(vendingMachine.MoneyPool == 0);
        }

        [Fact (DisplayName = "Purchase removes cost from money pool and returns the product")]
        public void Purchase()
        {
            vendingMachine.InsertMoney(50);

            Product product = vendingMachine.Purchase(1);

            Assert.Equal(38, vendingMachine.MoneyPool);
            Assert.Equal("Chocolate bar", product.Name);
        }

        [Fact(DisplayName = "Purchase with not enough money throws NotEnoughMoneyException")]
        public void PurchaseNotEnoughMoneyException()
        {
            vendingMachine.InsertMoney(5);

            var exception = Assert.Throws<NotEnoughMoneyException>(() => vendingMachine.Purchase(1));

            Assert.Equal("Not enough money to buy Chocolate bar", exception.Message);
        }

        [Fact(DisplayName = "Returns a list of all the items in the product repository")]
        public void ShowAll()
        {
            List<Product> products = vendingMachine.ShowAll();

            Assert.True(products.Count == 3);
            Assert.Equal("Chocolate bar", products.ElementAt(1).Name);
        }
    }
}
