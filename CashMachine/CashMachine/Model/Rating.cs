
namespace CashMachine.Model
{
    public class Rating
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public Rating(int value, string name, int count)
        {
            Value = value;
            Name = name;
            Count = count;
        }
    }
}
