using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineAssignment.model
{
    public class Juice : Product
    {
        public Juice(int cost, string name, string information) : base(cost, name, information)
        {

        }

        public override string Use()
        {
            return "Open lid and drink";
        }
    }
}
