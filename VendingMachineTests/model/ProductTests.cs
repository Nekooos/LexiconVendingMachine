using System;
using VendingMachineAssignment.model;
using Xunit;

namespace VendingMachineTests.model
{
    public class ProductTests
    {
        private Juice juice;
        private CandyBar candyBar;
        public ProductTests()
        {
            juice = new Juice(8, "Orange Juice", "Orange flavor");
            candyBar = new CandyBar(12, "Chocolate bar", "Chocolate Flavor");
        }

        [Fact(DisplayName = "returns a string containing price and information")]
        public void Examine()
        {
            String result = juice.Examine();
            String expected = "cost: 8 \nInformation: Orange flavor";

            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "returns a string containing how to use the item")]
        public void UseItemJuice()
        {
            String result = juice.Use();
            String expected = "Open lid and drink";

            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "returns a string containing how to use the item")]
        public void UseItemCandyBar()
        {
            String result = candyBar.Use();
            String expected = "Remove wrapper and eat";

            Assert.Equal(expected, result);
        }
    }
}
