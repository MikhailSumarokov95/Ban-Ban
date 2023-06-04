namespace ToxicFamilyGames
{
    public class Math
    {
        public static int SawChart(int value, int min, int max)
        {
            if (value > max) return min;
            else if (value < min) return max;
            else return value;
        }
    }
}
