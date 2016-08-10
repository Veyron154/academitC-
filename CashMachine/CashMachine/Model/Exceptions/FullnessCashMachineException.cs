
namespace CashMachine.Model.Exceptions
{
    internal class FullnessCashMachineException : CashMachineException
    {
        public string BillName { get; private set; }

        public FullnessCashMachineException(string billName)
        {
            BillName = billName;
        }
    }
}
