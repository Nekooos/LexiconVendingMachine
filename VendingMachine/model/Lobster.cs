using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineAssignment.model;

namespace VendingMachineAssignment.model
{
    public class Lobster : SeaCreature
    {
        public Lobster(int cost, string name, string information) : base(cost, name , information)
        {

        }
        public override string Use()
        {
            return "Remove shell and eat";
        }
    }
}
