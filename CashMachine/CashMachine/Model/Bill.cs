
namespace CashMachine.Model
{
    public class Bill
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public Bill(int value, string currency, int count)
        {
            Value = value;
            Name = $"{value} {currency}";
            Count = count;
        }
    }
}
