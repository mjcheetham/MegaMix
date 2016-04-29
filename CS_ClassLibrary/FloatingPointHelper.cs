using System;

namespace CS_ClassLibrary
{
    public static class FloatingPointHelper
    {
        public static bool AlmostEqual(double a, double b)
        {
            return Math.Abs(a - b) < 0.00000000000001;
        }
    }
}
