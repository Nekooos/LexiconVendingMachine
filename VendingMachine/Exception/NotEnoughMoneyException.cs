using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineAssignment.Exceptions
{
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException()
        {

        }

        public NotEnoughMoneyException(String message) : base (message)
        {

        }
    }
}
