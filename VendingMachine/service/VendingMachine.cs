using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VendingMachineAssignment.Exceptions;
using VendingMachineAssignment.model;
using VendingMachineAssignment.repository;

namespace VendingMachineAssignment.service
{
    public class VendingMachine : IVendingMachine
    {
        private ProductRepository productRepository;
        private int moneyPool; 
        private readonly int[] denominations = new int[] {1000, 500, 100, 50, 20, 10, 5, 1};

        public VendingMachine(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public int MoneyPool
        {
            get => moneyPool;
        }

        public Dictionary<int, int> EndTransaction()
        {
            Dictionary<int, int> coinsDictionay = new Dictionary<int, int>();
            if (moneyPool != 0)
            {
                foreach(int denomination in denominations)
                {
                    int coins = moneyPool / denomination;
                    coinsDictionay.Add(denomination, coins);
                    moneyPool = moneyPool - coins * denomination;
                }
            }
            return coinsDictionay;
        }                
            

        public int InsertMoney(int money)
        {
            if(ValidDenomination(money))
            {
                return moneyPool += money;
            } 
            else
            {
                throw new ArgumentException("Not a valid money input");
            }
        }

        public Product Purchase(int productNumber)
        {
            Product product = productRepository.GetAll().ElementAt(productNumber);

            if(product.Cost > moneyPool)
            {
                throw new NotEnoughMoneyException($"Not enough money to buy {product.Name}");
            } 
            else
            {
                moneyPool -= product.Cost;
            }
            return product;
        }

        public List<String> ShowAll()
        {
            List<Product> products = productRepository.GetAll();
            return Enumerable.Range(0, products.Count).Select(i => "" + (i + 1) + " " + products.ElementAt(i).Name).ToList();
        }

        private bool ValidDenomination(int money)
        {
            foreach (int denomination in denominations)
            {
                if (money == denomination)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
