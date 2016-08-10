
namespace CashMachine.Model.Exceptions
{
    internal class InvalidValueOfBillException : CashMachineException
    {
        public string BillName { get; private set; }

        public InvalidValueOfBillException(string billName)
        {
            BillName = billName;
        }
    }
}
