namespace RawFeederLib.Classes
{
    public class Meat
    {
        public Meat(string name) => Name = name;

        public string Brand { get; set; }
        public string Name { get; set; }
        public decimal CostPerGram { get; set; }
        public decimal WeightInGrams { get; set; }
    }
}