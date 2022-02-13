namespace RawFeederLib.Classes
{
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
}