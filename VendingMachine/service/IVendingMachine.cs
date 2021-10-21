using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineAssignment.model;

namespace VendingMachineAssignment.service
{
    public interface IVendingMachine
    {
        Product Purchase(int input);
        List<String> ShowAll();
        int InsertMoney(int money);
        Dictionary<int, int> EndTransaction();
    }
}
