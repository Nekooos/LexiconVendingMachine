using System;
using VendingMachineAppMenu;
using VendingMachineAssignment.model;
using VendingMachineAssignment.repository;

namespace VendingMachineProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachineApp vendingMachineApp = new VendingMachineApp();
            vendingMachineApp.Start();

        }
    }
}
