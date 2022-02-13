using RawFeederLib.Classes;

namespace RawFeederLib
{
    public interface ICalculateMeal
    {
        (int, int) CalculateGramsToEat(int currentAgeInMonths, int currentWeightInGrams);
        Meal GenerateMeal(int gramsToEatLower, int gramsToEatUpper, Meat meat, Bone bone, Offal offal);
    }
}
