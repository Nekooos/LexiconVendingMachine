using System.Collections.Generic;
using VendingMachineAssignment.model;

namespace VendingMachineAssignment.repository
{
    public class ProductRepository
    {
        private readonly List<Product> products;

        public ProductRepository()
        {

        }

        public ProductRepository(List<Product> products)
        {
            this.products = products;
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}
