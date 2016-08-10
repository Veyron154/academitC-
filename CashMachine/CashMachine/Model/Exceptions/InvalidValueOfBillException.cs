using System;

namespace CashMachine.Model.Exceptions
{
    internal class InvalidValueOfBillException : Exception
    {
        public string BillName { get; private set; }

        public InvalidValueOfBillException(string billName)
        {
            BillName = billName;
        }
    }
}
