using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineTests.service
{
    class VendingMachineData
    {
        public static IEnumerable<object[]> InsertCoinsData =>
            new List<object[]>
    {
                new object[] { 1, 1},
                new object[] { 5, 5 },
                new object[] { 10, 10 },
                new object[] { 20, 20 },
                new object[] { 50, 50 },
                new object[] { 100, 100 },
                new object[] { 500, 500 },
                new object[] { 1000, 1000 }
    };
    }
}
