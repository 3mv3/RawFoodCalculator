using Xamarin.Forms;
//using RawFeederLib;
//using RawFeederLib.Classes;
using System.Windows.Input;
using System.ComponentModel;

namespace RawFeederApp.ViewModels
{
    public class RawFeederModel : INotifyPropertyChanged
    {
        public enum CurrentStates
        {
            AgeEntry,
            FoodEntry
        }
        public CurrentStates CurrentState { get; set; }
        public bool IsEnteringAge => CurrentState == CurrentStates.AgeEntry;
        public bool IsEnteringFood => CurrentState == CurrentStates.FoodEntry;
        //private MealGenerator MealGen;
        //public Meat CurrentMeat { get; set; }
        //public Bone CurrentBone { get; set; }
        //public Offal CurrentOffal { get; set; }
        //public Complete CurrentComplete { get; set; }
        public (int,int) FeedingRange { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string CurrentMeat { get; set; }
        public string CurrentBone { get; set; }
        public string CurrentOffal { get; set; }
        public void Calculate()
        {
            // do stuff
            Meal = $"{CurrentMeat} / {CurrentBone} / {CurrentOffal}";
        }
        public string Meal { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //public RawFeederModel() => MealGen = new MealGenerator();

        //public void SetMeat(string name, decimal weight) => CurrentMeat = new Meat(name) { WeightInGrams = weight };
        //public void SetBone(string name, int percentage, decimal weight) => CurrentBone = new Bone(name, percentage) { WeightInGrams = weight };
        //public void SetOffal(string name, decimal weight) => CurrentOffal = new Offal(name) { WeightInGrams = weight };
        //public void SetComplete(string name, int bonePercentage, int offalPercentage, decimal weight) => CurrentComplete = new Complete(name, bonePercentage, offalPercentage) { WeightInGrams = weight };
        //public void SetRanges() => FeedingRange = MealGen.CalculateGramsToEat(Age, Weight);
    }
}