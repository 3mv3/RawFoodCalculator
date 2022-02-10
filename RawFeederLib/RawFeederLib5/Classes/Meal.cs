namespace RawFeederLib.Classes
{
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
}