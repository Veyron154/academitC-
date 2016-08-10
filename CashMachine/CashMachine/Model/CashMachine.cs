using System.Collections.Generic;
using System.Linq;
using CashMachine.Model.Exceptions;

namespace CashMachine.Model
{
    public class CashMachine
    {
        private int _sum;

        public int TotalCountOfMoney
        {
            get
            {
                return ListOfBills.Sum(rating => rating.Value*rating.Count);
            }
        }

        public List<Bill> ListOfBills { get; }
        public int MaxCountOfBills { get; }
       
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
        }
        
        public int PutCash(List<int> listOfTextBoxesValues)
        {
            for (var i = 0; i < listOfTextBoxesValues.Count; ++i)
            {
                if (listOfTextBoxesValues[i] < 0)
                {
                    throw new InvalidValueOfBillException(ListOfBills[i].Name);
                }
            }

            for (var i = 0; i < listOfTextBoxesValues.Count; ++i)
            {
                var bill = ListOfBills[i];
                if (!CheckToFullness(listOfTextBoxesValues[i], bill.Count))
                {
                    throw new FullnessCashMachineException(bill.Name);
                }
            }

            var sum = 0;
            for (var i = 0; i < listOfTextBoxesValues.Count; ++i)
            {
                var bill = ListOfBills[i];
                bill.Count += listOfTextBoxesValues[i];
                sum += listOfTextBoxesValues[i] * bill.Value;
            }
            return sum;
        }

        public List<int> GetCash(string textBoxText, int index, int sum)
        {
            _sum = sum;
            if (_sum <= 0 || _sum % 10 != 0)
            {
                throw  new InvalidValueOfSumException();
            }

            if (_sum > TotalCountOfMoney)
            {
                throw new ExceedingSumException();
            }

            var listOfCountsOfBills = ListOfBills.Select(bill => new int()).ToList();

            listOfCountsOfBills[index] = CalculateBills(ListOfBills[index].Value, ListOfBills[index].Count);

            for (var i = listOfCountsOfBills.Count - 1; i >= 0; --i)
            {
                if (i == index)
                {
                    continue;
                }
                var bill = ListOfBills[i];
                listOfCountsOfBills[i] = CalculateBills(bill.Value, bill.Count);
            }

            if (_sum != 0)
            {
                throw new ImpossibleCashCombinationException();
            }

            for (var i = 0; i < listOfCountsOfBills.Count; ++i)
            {
                ListOfBills[i].Count -= listOfCountsOfBills[i];
            }
            return listOfCountsOfBills;
        }

        private int CalculateBills(int cash, int countOfBills)
        {
            var requestedCountOfBills = _sum / cash;
            if (requestedCountOfBills > countOfBills)
            {
                requestedCountOfBills = countOfBills;
            }
            _sum -= requestedCountOfBills * cash;
            return requestedCountOfBills;
        }

        private bool CheckToFullness(int countOfBills, int curentCountOfBills)
        {
            return countOfBills + curentCountOfBills <= MaxCountOfBills;
        }
    }
}
