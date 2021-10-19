using System.Collections.Generic;
using Xunit;
using VendingMachineAssignment.model;
using VendingMachineAssignment.repository;
using System.Linq;

namespace VendingMachineTests.repository
{
    public class ProductRepositoryTests
    {
        private ProductRepository productRepository;

        public ProductRepositoryTests()
        {
            List<Product> products = new List<Product>()
            {
                new Juice(8, "Orange Juice", "Orange Flavor"),
                new CandyBar(12, "Chocolate bar", "Chocolate Flavor"),
                new Lobster(128, "Lobster", "Chocolate Flavor")
            };
            productRepository = new ProductRepository(products);
        }

        [Fact]
        public void getAll()
        {
            List<Product> products = productRepository.GetAll();

            Assert.True(products.Count == 3);
            Assert.Equal("Chocolate bar", products.ElementAt(1).Name);
        }
    }
}
