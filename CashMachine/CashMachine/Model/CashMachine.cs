using System.Collections.Generic;
using System.Linq;

namespace CashMachine.Model
{
    public class CashMachine
    {
        public List<Bill> ListOfBills { get; }
        public int TotalCountOfMoney { get; private set; }
        public int MaxCountOfBills { get; private set; }

        public CashMachine()
        {
            const string currency = "руб.";
            const int defaultCount = 50;
            ListOfBills = new List<Bill>
            {
                new Bill(10, currency, defaultCount),
                new Bill(50, currency, defaultCount),
                new Bill(100, currency, defaultCount),
                new Bill(500, currency, defaultCount),
                new Bill(1000, currency, defaultCount),
                new Bill(5000, currency, defaultCount)
            };

            MaxCountOfBills = 100;

            CalculateMoney();
        }

        public void CalculateMoney()
        {
            var sum = ListOfBills.Sum(rating => rating.Value*rating.Count);
            TotalCountOfMoney = sum;
        }
    }
}
