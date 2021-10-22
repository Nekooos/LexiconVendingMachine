using System;

namespace VendingMachineAssignment.model
{
    public abstract class SeaCreature : Product
    {
        public SeaCreature(int price, String name, String information) : base(price, name, information)
        {

        }

        public abstract override string Use();
    }
}
