
namespace CashMachine.Model
{
    public class CashMachine
    {
        public int CountOfTenBills { get; set; }
        public int CountOfFiftyBills { get; set; }
        public int CountOfHundredBills { get; set; }
        public int CountOfFiveHundredBills { get; set; }
        public int CountOfThousandBills { get; set; }
        public int CountOfFiveThousandBills { get; set; }
        public int TotalCountOfMoney { get; private set; }
        public int MaxCountOfBills { get; private set; }

        public CashMachine()
        {
            CountOfTenBills = 50;
            CountOfFiftyBills = 50;
            CountOfHundredBills = 50;
            CountOfFiveHundredBills = 50;
            CountOfThousandBills = 50;
            CountOfFiveThousandBills = 50;

            MaxCountOfBills = 100;

            CalculateMoney();
        }

        public void CalculateMoney()
        {
            var sum = 0;
            sum += CountOfTenBills * 10;
            sum += CountOfFiftyBills * 50;
            sum += CountOfHundredBills * 100;
            sum += CountOfFiveHundredBills * 500;
            sum += CountOfThousandBills * 1000;
            sum += CountOfFiveThousandBills * 5000;
            TotalCountOfMoney = sum;
        }
    }
}
