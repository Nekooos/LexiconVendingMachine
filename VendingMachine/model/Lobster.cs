using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineAssignment.model
{
    class Lobster : Product
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
