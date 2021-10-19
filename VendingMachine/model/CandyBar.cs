using System;

namespace VendingMachineAssignment.model
{
    public class CandyBar : Product
    {
        public CandyBar(int price, String name, String information) : base(price, name, information)
        {

        }

        public override String Use()
        {
            return "Remove wrapper and eat";
        }
    }
}
