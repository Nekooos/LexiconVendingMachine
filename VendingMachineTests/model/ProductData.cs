using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineAssignment.model;

namespace VendingMachineTests.model
{
    class ProductData
    {
        public static IEnumerable<object[]> ProductDataUse =>
            new List<object[]>
            {
                new object[] { new Juice(8, "Orange Juice", "Orange Flavor"), "Open lid and drink" },
                new object[] { new CandyBar(12, "Chocolate bar", "Chocolate Flavor"), "Remove wrapper and eat" },
                new object[] { new Lobster(128, "Lobster", "Chocolate Flavor"), "Remove shell and eat" }
            };

        public static IEnumerable<object[]> ProductDataInformation =>
            new List<object[]>
            {
                new object[] { new Juice(8, "Orange Juice", "Orange Flavor"), "Cost: 8\nInformation: Orange Flavor" },
                new object[] { new CandyBar(12, "Chocolate bar", "Chocolate Flavor"), "Cost: 12\nInformation: Chocolate Flavor" },
                new object[] { new Lobster(128, "Lobster", "Lobster Flavor"), "Cost: 128\nInformation: Lobster Flavor" }
            };
    }
}
