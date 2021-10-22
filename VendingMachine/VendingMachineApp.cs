using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachineAssignment.Exceptions;
using VendingMachineAssignment.model;
using VendingMachineAssignment.repository;
using VendingMachineAssignment.service;

namespace VendingMachineAppMenu
{
    class VendingMachineApp
    {
        private readonly VendingMachine vendingMachine;
        private bool isRunning = true;
        public VendingMachineApp()
        {
         
            var productRepository = new ProductRepository(AddProducts());
            vendingMachine = new VendingMachine(productRepository);
        }

        public void Start()
        {
            while(isRunning)
            {
                ShowMenu();
                int input = validInput("Enter a number");
                ExecuteMenuChoice(input);
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("1. Products\n2. Insert Money\n3. End Transaction\n4. Exit");
        }

        private int validInput(string message)
        {
            int input = 0;
            bool isValid = false;

            while (!isValid) {
                Console.WriteLine(message);
                isValid = int.TryParse(Console.ReadLine(), out input);

                if (!isValid)
                    Console.WriteLine("Not a valid menu choice");
            }
            return input;

        }

        private void ShowProducts(List<String> products)
        {
            products.ForEach(product => Console.WriteLine(product));
        }

        public List<Product> AddProducts()
        {
            return new List<Product>()
            {
                new Juice(8, "Orange Juice", "Orange flavor"),
                new Juice(12, "Apple Juice", "Apple flavor"),
                new Juice(15, "Mango Juice", "Mango flavor"),
                new CandyBar(12, "Chocolate bar", "Chocolate Flavor"),
                new CandyBar(22, "Protein bar", "Meat Flavor"),
                new Lobster(122, "Cooked Lobster", "Lobster Flavor"),
                new Lobster(599, "Cooked Blue Lobster", "Blue Lobster Flavor"),
            };
        }

        public void ExecuteMenuChoice(int input)
        {
            switch(input)
            {
                case 1:
                    List<String> products = vendingMachine.ShowAll();
                    ShowProducts(products);
                    int buyInput = validInput("What do you want to buy?");
                    Product product;
                    try
                    {
                        product = vendingMachine.Purchase(buyInput - 1);
                        Console.WriteLine($"You bought {product.Name}. You have {vendingMachine.MoneyPool} left");
                    }
                    catch(NotEnoughMoneyException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    break;

                case 2:
                    int money = validInput("How much do you want to insert");
                    try
                    {
                        int moneyPool = vendingMachine.InsertMoney(money);
                        Console.WriteLine($"You have {moneyPool}");
                    }
                    catch(ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    break;

                case 3:

                    Dictionary<int, int> coins = vendingMachine.EndTransaction();
                    Console.WriteLine("Coins returned: ");
                    coins.ToList()
                        .Where(keyValue => keyValue.Value != 0)
                        .ToList()
                        .ForEach(keyValue => Console.WriteLine($"{keyValue.Value} st {keyValue.Key} kr"));
                    break;

                default:

                    isRunning = false;
                    break;


            }
        }


    }
}
