using System;
using VendingMachineAssignment.model;
using Xunit;

namespace VendingMachineTests.model
{
    public class ProductTests
    {

        [Theory(DisplayName = "returns a string containing price and information")]
        [MemberData(nameof(ProductData.ProductDataInformation), MemberType = typeof(ProductData))]
        public void ExamineProduct(Product product, String expectedInformation)
        {
            String result = product.Examine();
            Assert.Equal(expectedInformation, result);
        }

        [Theory(DisplayName = "returns a string containing how to use the item")]
        [MemberData(nameof(ProductData.ProductDataUse), MemberType = typeof(ProductData))]
        public void UseProduct(Product product, String expectedUse)
        {
            String result = product.Use();
            Assert.Equal(expectedUse, result);
        }
    }
}
