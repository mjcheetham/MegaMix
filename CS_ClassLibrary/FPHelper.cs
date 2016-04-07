using System;

namespace CS_ClassLibrary
{
    internal static class FloatingPointHelper
    {
        public static bool AlmostEqual(double a, double b)
        {
            return Math.Abs(a - b) < double.Epsilon;
        }
    }
}
