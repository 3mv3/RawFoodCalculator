using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace RawFeeder
{
    class MainClass
    {
        public static List<Meat> MeatList = new List<Meat>
        {
            new Meat("Venison Mince") { CostPerGram = .65m },
            new Meat("Goat Chunks") { Brand = "PRTC", CostPerGram = 1200m/1000 },
            new Meat("Lamb") { CostPerGram = .23m },
            new Meat("Venison Chunks") { Brand = "NTN", CostPerGram = 750m/1000 },
            new Meat("Duck Chunks") { Brand = "NTN", CostPerGram = 525m/1000 },
            new Meat("Beef Chunks") { Brand = "NTN", CostPerGram = 650m/1000 },
            new Meat("Beef Chunks") { Brand = "Natures Menu", CostPerGram = 500m/1000 },
            new Meat("Beef Chunks") { Brand = "PRTC", CostPerGram = 390m/1000 },
            new Meat("Pork Chunks") { Brand = "NTN", CostPerGram = 590m/1000 },
            new Meat("Turkey Chunks") { Brand = "NTN", CostPerGram = 650m/1000 },
            new Meat("Chicken Breast Chunks") { Brand = "NTN", CostPerGram = 595m/1000 },
            new Meat("Herring Flap Chunks") { Brand = "PRTC", CostPerGram = 340m/1000 },
            new Meat("Salmon Chunks") { Brand = "PRTC", CostPerGram = 395m/1000 },
            new Meat("Horse Meat Chunks") { Brand = "TBD", CostPerGram = 630m/1000 },
            new Meat("Veal Chunks") { Brand = "TBD", CostPerGram = 570m/1000 },
            new Meat("White Fish Chunks") { Brand = "PRTC", CostPerGram = 350m/1000 }
        };

        public static List<Complete> CompleteList = new List<Complete>
        {
            new Complete("Chicken Drumstick", 30, 0) { CostPerGram = 350m/1000 },
            new Complete("Duck Neck", 50, 0) { Brand = "TBD", CostPerGram = 390m/1000 },
            new Complete("Duck Leg", 35, 0) { CostPerGram = .32m },
            new Complete("Duck Wing", 40, 0) { Brand = "TBD", CostPerGram = 350m/1000 },
            new Complete("Veal Rib", 35, 0) { CostPerGram = 350m/1000 },
            new Complete("Whole Quail", 10, 0) { CostPerGram = 390m/200 },
            new Complete("Duck Feet", 60, 0) { Brand = "PR", CostPerGram = 385m/600 },
            new Complete("Whole Duck", 30, 0) { Brand = "PRTC", CostPerGram = 340m/1200 },
            new Complete("Goose Neck", 50, 0) { Brand = "PRTC", CostPerGram = 360m/1000 },
            new Complete("Duck Carcass Mince", 50, 0) { Brand = "TBD", CostPerGram = 290m/100 }
        };

        public static List<Offal> OffalList = new List<Offal>
        {
            new Offal("Testicles") { Brand = "TBD", CostPerGram = 260m/400 },
            new Offal("Kidney") { CostPerGram = .1m } ,
            new Offal("Spleen") { CostPerGram = .1m },
            new Offal("Lung") { CostPerGram = .1m },
            new Offal("Liver (Chicken)") { Brand = "NTN", CostPerGram = 335m/500 }
        };

        public static Dictionary<int, (int,int)> AgeToBodyMass { get; set; } = new Dictionary<int, (int,int)>
        {
            { 1, (3,5) },
            { 11, (3, 5) }
        };
        
        public static void Main(string[] args)
        {
            var userInput = "";

            Console.WriteLine("Enter dog weight in grams");
            var dogWeight = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter dog age in months");
            var dogAge = int.Parse(Console.ReadLine());

            var nearestAge = AgeToBodyMass.Keys.Aggregate((x, y) => Math.Abs(x - dogAge) < Math.Abs(y - dogAge) ? x : y);
            var bodyMassPercentage = AgeToBodyMass[nearestAge];
            var gramsToEatLower = (dogWeight / 100) * bodyMassPercentage.Item1;
            var gramsToEatUpper = (dogWeight / 100) * bodyMassPercentage.Item2;

            Console.WriteLine($"Dog needs between {gramsToEatLower}g - {gramsToEatUpper}g");
            var genAgain = true;

            Console.WriteLine("Enter Y if you already have ingredients");
            var ownIngredients = Console.ReadLine().Equals("Y", StringComparison.CurrentCultureIgnoreCase);
            var currentMeat = default(Meat);
            var currentBone = default(Bone);
            var currentOffal = default(Offal);

            if(ownIngredients)
            {
                Console.WriteLine("Enter meat (zero bone content)");
                userInput = Console.ReadLine();
                currentMeat = MeatList.FirstOrDefault(x => x.Name.Equals(userInput, StringComparison.InvariantCultureIgnoreCase));

                if (currentMeat != null)
                {
                    Console.WriteLine("Enter meat weight");
                    currentMeat.WeightInGrams = decimal.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Meat information not found, using random meat.");
                }

                Console.WriteLine("Enter bone / complete meal");
                userInput = Console.ReadLine();
                currentBone = CompleteList.FirstOrDefault(x => x.Name.Equals(userInput, StringComparison.InvariantCultureIgnoreCase));

                if (currentBone != null)
                {
                    Console.WriteLine("Enter bone weight");
                    currentBone.WeightInGrams = decimal.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Bone information not found, using random bone.");
                }

                Console.WriteLine("Enter offal");
                userInput = Console.ReadLine();
                currentOffal = OffalList.FirstOrDefault(x => x.Name.Equals(userInput, StringComparison.InvariantCultureIgnoreCase));

                if (currentOffal != null)
                {
                    Console.WriteLine("Enter offal weight");
                    currentOffal.WeightInGrams = decimal.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Offal information not found, using random offal.");
                }
            }

            while (genAgain)
            {
                genAgain = false;
                GenerateMeal(gramsToEatLower, gramsToEatUpper, currentMeat, currentBone, currentOffal);

                Console.WriteLine("Enjoy!");
                Console.WriteLine("Press Y to Generate again");

                genAgain = Console.ReadLine().Equals("Y", StringComparison.CurrentCultureIgnoreCase);
            }
        }

        public static void GenerateMeal(int gramsToEatLower,
            int gramsToEatUpper,
            Meat meat,
            Bone bone,
            Offal offal)
        {
            var meal = new EightyTenTen();

            var meatToEatLower = (gramsToEatLower / 100) * meal.MeatRatio;
            var boneToEatLower = (gramsToEatLower / 100) * meal.BoneRatio;
            var offalToEatLower = ((gramsToEatLower / 100) * meal.OffalRatio) / 2;

            var meatToEatUpper = (gramsToEatUpper / 100) * meal.MeatRatio;
            var boneToEatUpper = (gramsToEatUpper / 100) * meal.BoneRatio;
            var offalToEatUpper = ((gramsToEatUpper / 100) * meal.OffalRatio) / 2;

            var boneEntered = false;
            var meatEntered = false;
            var offalEntered = false;

            if (bone == null)
                bone = GetRandom(CompleteList);
            else
                boneEntered = true;

            if (meat == null)
                meat = GetRandom(MeatList);
            else
                meatEntered = true;

            var nonLiver = OffalList.Where(x => !x.Name.Contains("Liver")).ToList();
            if (offal == null)
                offal = GetRandom(nonLiver);
            else
                offalEntered = true;

            // Need 80g bone
            // Duck wing 40% bone
            // 80/.4 = x

            // E.g If using a complete mince
            //if (meat.BoneContentPercentage > 0)
            //{
            //    // If user entered
            //    if (meatEntered && meat.WeightInGrams < meatToEatLower)
            //    {
            //        // We need to lower the required bone to eat if the meat is already high in bone
            //        boneToEatLower -= (int)decimal.Round(meat.WeightInGrams * (meat.BoneContentPercentage / 100), 0);
            //    }
            //    else
            //    {
            //        boneToEatLower -= (int)decimal.Round(meatToEatLower * (meat.BoneContentPercentage / 100), 0);
            //    }
            //}

            var lowerMeatGramsIncludingBone = decimal.Round(boneToEatLower / (bone.BoneContentPercentage / 100), 0);
            var upperMeatGramsIncludingBone = decimal.Round(boneToEatUpper / (bone.BoneContentPercentage / 100), 0);

            var lowerMeatSurplus = decimal.Round(lowerMeatGramsIncludingBone * (bone.MeatContentPercentage / 100), 0);
            var upperMeatSurplus = decimal.Round(upperMeatGramsIncludingBone * (bone.MeatContentPercentage / 100), 0);

            var lowerAmountOfMeat = (meatToEatLower - lowerMeatSurplus);
            var upperAmountOfMeat = (meatToEatUpper - upperMeatSurplus);

            meal.Meat = $"{meat.Name}: {lowerAmountOfMeat}g-{upperAmountOfMeat}g";
            meal.Bone = $"{bone.Name}: {lowerMeatGramsIncludingBone}g-{upperMeatGramsIncludingBone}g";
            meal.Offal = $"{offal.Name}: {offalToEatLower}g-{offalToEatUpper}g";
            meal.Liver = $"{offalToEatLower}g-{offalToEatUpper}g";

            // Adjust based on user entry
            if (meatEntered && (meat.WeightInGrams + lowerMeatSurplus) < lowerAmountOfMeat)
            {
                // Extra meat needed
                var extraMeat = MeatList.Where(x => x.Name != meat.Name)
                    .ToList()[new Random().Next(0, MeatList.Count - 2)];

                var remaining = lowerAmountOfMeat - meat.WeightInGrams;

                meal.Meat = $"{meat.Name}: {meat.WeightInGrams}g + {extraMeat.Name}: {remaining}g";
            }

            if (boneEntered && bone.BoneContentGrams < boneToEatLower)
            {
                // Extra bone needed
                var extraBone = CompleteList.Where(x => x.Name != bone.Name)
                    .ToList()[new Random().Next(0, CompleteList.Count - 2)];

                var remaining = boneToEatLower - bone.BoneContentGrams;
                var remainingMeatGramsIncludingBone = decimal.Round(remaining / (extraBone.BoneContentPercentage / 100), 0);

                meal.Bone = $"{bone.Name}: {bone.WeightInGrams}g + {extraBone.Name}: {remainingMeatGramsIncludingBone}g";
            }

            if (offalEntered && offal.WeightInGrams < offalToEatLower)
            {
                // Extra offal needed
                var extraOffal = OffalList.Where(x => x.Name != offal.Name)
                    .ToList()[new Random().Next(0, OffalList.Count - 2)];

                var remaining = offalToEatLower - offal.WeightInGrams;

                meal.Offal = $"{offal.Name}: {offal.WeightInGrams}g + {extraOffal.Name}: {remaining}g";
            }

            var liverCost = OffalList.First(x => x.Name.Contains("Liver")).CostPerGram;

            var lowerCost = decimal.Round((meat.CostPerGram * lowerAmountOfMeat) +
            (bone.CostPerGram * lowerMeatGramsIncludingBone) +
            (offal.CostPerGram * offalToEatLower) +
            (liverCost * offalToEatLower), 2);

            var upperCost = decimal.Round((meat.CostPerGram * upperAmountOfMeat) +
                (bone.CostPerGram * upperMeatGramsIncludingBone) +
                (offal.CostPerGram * offalToEatUpper) +
                (liverCost * offalToEatUpper),2);

            meal.TotalCost = $"£{decimal.Round(lowerCost/100,2)}-£{decimal.Round(upperCost/100,2)}";

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(meal))
            {
                if(descriptor.PropertyType == typeof(string))
                {
                    var name = descriptor.Name;
                    var value = descriptor.GetValue(meal);
                    Console.WriteLine("{0}={1}", name, value);
                }
            }
        }

        public static T GetRandom<T>(IList<T> list) => list[new Random().Next(0, list.Count - 1)];
    }

    public class EightyTenTen : Meal
    {
        public override int MeatRatio => 80;
        public override int BoneRatio => 10;
        public override int OffalRatio => 10;
    }

    public class Meal
    {
        public string TotalCost { get; set; }

        public virtual int MeatRatio { get; set; }
        public virtual int BoneRatio { get; set; }
        public virtual int OffalRatio { get; set; }

        public string Meat { get; set; }
        public string Bone { get; set; }
        public string Offal { get; set; }
        public string Liver { get; set; }
    }

    public class Bone: Meat
    {
        public Bone(string name, int bonePercentage) : base(name)
        {
            BoneContentPercentage = bonePercentage;
        }

        private decimal _boneContentGrams { get; set; }
        public decimal BoneContentGrams
        {
            get
            {
                if (BoneContentPercentage > 0 && WeightInGrams > 0)
                    return WeightInGrams * (BoneContentPercentage / 100);
                else
                    return _boneContentGrams;
            }
            set => _boneContentGrams = value;
        }
        public decimal BoneContentPercentage { get; set; }

        private decimal _meatContentGrams { get; set; }
        public decimal MeatContentGrams
        {
            get
            {
                if (MeatContentPercentage > 0 && WeightInGrams > 0)
                    return WeightInGrams * (MeatContentPercentage / 100);
                else
                    return _meatContentGrams;
            }
            set => _meatContentGrams = value;
        }

        public decimal MeatContentPercentage => 100 - BoneContentPercentage;
    }

    public class Offal : Meat
    {
        public Offal(string name) : base(name){ }
    }

    public class Complete : Bone
    {
        public Complete(string name, int bonePercentage, int offalPercentage) : base(name, bonePercentage)
        {
            OffaContentPercentage = offalPercentage;
        }

        private decimal _offalContentGrams { get; set; }
        public decimal OffalContentGrams
        {
            get
            {
                if (OffaContentPercentage > 0 && WeightInGrams > 0)
                    return WeightInGrams * (OffaContentPercentage / 100);
                else
                    return _offalContentGrams;
            }
            set => _offalContentGrams = value;
        }

        public decimal OffaContentPercentage { get; set; }
    }

    public class Meat
    {
        public Meat(string name) => Name = name;

        public string Brand { get; set; }
        public string Name { get; set; }
        public decimal CostPerGram { get; set; }
        public decimal WeightInGrams { get; set; }
    }
}