namespace RawFeederLib.Classes
{
    public class Bone : Meat
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
}