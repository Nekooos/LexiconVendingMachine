using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineAssignment.Exceptions
{
    class NotEnoughMoneyException : Exception
    {

        public NotEnoughMoneyException()
        {

        }

        public NotEnoughMoneyException(String message) : base (message)
      {

      }
    }
}
