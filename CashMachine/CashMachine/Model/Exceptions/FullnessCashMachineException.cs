
using System;

namespace CashMachine.Model.Exceptions
{
    internal class FullnessCashMachineException : Exception
    {
        public string BillName { get; private set; }

        public FullnessCashMachineException(string billName)
        {
            BillName = billName;
        }
    }
}
