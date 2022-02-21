using System;

namespace CalcLibrary.Models
{
    public static class MathFunc
    {
        public static float Sum(float var1, float var2)
        {
            return var1 + var2;
        }

        public static float Sub(float var1, float var2)
        {
            return var1 - var2;
        }

        public static float Mult(float var1, float var2)
        {
            return var1 * var2;
        }

        public static float Dev(float var1, float var2)
        {
            return var1 / var2;
        }

        public static float Percentage(float var1, float var2)
        {
            return var1 / 100 * var2;
        }

        public static float Sqrt(float var1)
        {
            return (float)Math.Sqrt(var1);
        }

        public static float Squaring(float var1)
        {
            return (float)Math.Pow(var1, 2);
        }

        public static float OneDividedByNumber(float var1)
        {
            return 1 / var1;
        }

        public static float SignChange(float var1)
        {
            return -1 * var1;
        }
    }
}
