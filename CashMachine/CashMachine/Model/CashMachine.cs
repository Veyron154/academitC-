using System;
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
            if (listOfCountsOfBills[index] == ListOfBills[index].Count && index != ListOfBills.Count - 1 && 
                ListOfBills[index].Count * ListOfBills[index].Value != _sum)
            {
                var tmpIndex = index + 1;
                while (tmpIndex < ListOfBills.Count)
                {
                    if ((ListOfBills[index].Value*ListOfBills[index].Count +
                         ListOfBills[tmpIndex].Value*ListOfBills[tmpIndex].Count) >= _sum)
                    {
                        break;
                    }
                    ++tmpIndex;
                }

                double remainder = _sum % ListOfBills[tmpIndex].Value;
                var leastCommonMiltiple = GetLeastCommonMultiple(ListOfBills[index].Value, ListOfBills[tmpIndex].Value);
                listOfCountsOfBills[index] -= (int)Math.Ceiling((leastCommonMiltiple - remainder)/ListOfBills[index].Value);
            }
            _sum -= listOfCountsOfBills[index] * ListOfBills[index].Value;

            for (var i = listOfCountsOfBills.Count - 1; i >= 0; --i)
            {
                if (i == index)
                {
                    continue;
                }
                var bill = ListOfBills[i];
                listOfCountsOfBills[i] = CalculateBills(bill.Value, bill.Count);
                _sum -= listOfCountsOfBills[i] * bill.Value;
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
            return requestedCountOfBills;
        }

        private bool CheckToFullness(int countOfBills, int curentCountOfBills)
        {
            return countOfBills + curentCountOfBills <= MaxCountOfBills;
        }

        private static int GetLeastCommonMultiple(int firstInputNumber, int secondInputNumber)
        {
            var firstNumber = firstInputNumber;
            var secondNumber = secondInputNumber;
            while (secondNumber != 0)
            {
                var tmp = firstNumber;
                firstNumber = secondNumber;
                secondNumber = tmp % secondNumber;
            }
            return (firstInputNumber * secondInputNumber) / firstNumber;
        }
    }
}
