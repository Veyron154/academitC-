using System.Collections.Generic;

namespace CashMachine.Model
{
    public class CashMachine
    {
        public List<Rating> ListOfRatings { get; private set; }
        public int TotalCountOfMoney { get; private set; }
        public int MaxCountOfBills { get; private set; }

        public CashMachine()
        {
            ListOfRatings = new List<Rating>();
            ListOfRatings.Add(new Rating(10, "10 руб.", 50));
            ListOfRatings.Add(new Rating(50, "50 руб.", 50));
            ListOfRatings.Add(new Rating(100, "100 руб.", 50));
            ListOfRatings.Add(new Rating(500, "500 руб.", 50));
            ListOfRatings.Add(new Rating(1000, "1000 руб.", 50));
            ListOfRatings.Add(new Rating(5000, "5000 руб.", 50));

            MaxCountOfBills = 100;

            CalculateMoney();
        }

        public void CalculateMoney()
        {
            var sum = 0;
            foreach (var rating in ListOfRatings)
            {
                sum += rating.Value * rating.Count;
            }
            TotalCountOfMoney = sum;
        }
    }
}
