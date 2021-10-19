using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineAssignment.model
{
    public abstract class Product
    {
        public int Cost { get; set; }
        public String Name { get; set; }
        public String Information { get; set; }

        protected Product(int cost, String name, String information)
        {
            Cost = cost; 
            Name = name;
            Information = information;
        }

        public String Examine()
        {
            return $"cost: {Cost} \nInformation: {Information}";
        }

        public abstract String Use();
    }
}
