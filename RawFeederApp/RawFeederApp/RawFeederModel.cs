using System.ComponentModel;
using RawFeederLib;
using RawFeederLib.Classes;

namespace RawFeederApp.ViewModels
{
    public class RawFeederModel : INotifyPropertyChanged
    {
        private MealGenerator MealGen;
        public Meat CurrentMeat { get; set; }
        public Bone CurrentBone { get; set; }
        public Offal CurrentOffal { get; set; }
        public Complete CurrentComplete { get; set; }
        public (int,int) FeedingRange { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public void Calculate()
        {
            Meal = $"{FeedingRange.Item1}:{FeedingRange.Item2} of {CurrentMeat.Name} / {CurrentBone.Name} / {CurrentOffal.Name}";
        }
        public string Meal { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RawFeederModel() => MealGen = new MealGenerator();

        public void SetMeat(string name, decimal weight) => CurrentMeat = new Meat(name) { WeightInGrams = weight };
        public void SetBone(string name, int percentage, decimal weight) => CurrentBone = new Bone(name, percentage) { WeightInGrams = weight };
        public void SetOffal(string name, decimal weight) => CurrentOffal = new Offal(name) { WeightInGrams = weight };
        public void SetComplete(string name, int bonePercentage, int offalPercentage, decimal weight) => CurrentComplete = new Complete(name, bonePercentage, offalPercentage) { WeightInGrams = weight };
        public void SetRanges() => FeedingRange = MealGen.CalculateGramsToEat(Age, Weight);
    }
}