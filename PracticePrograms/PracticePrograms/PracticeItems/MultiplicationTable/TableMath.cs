using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems
{
    public static class TableMath
    {
        public static bool IsSquare(double i, out double result)
        {
            double calc = Math.Sqrt(i);
            if (calc % 1 == 0)
            {
                result = 0;
                return true;
            }
            else
            {
                result = calc;
                return false;
            }
        }

        public static int FindNextSquare(int i)
        {
            Skew s = Skew.None;
            var result = FindNextSquare(i, s);
            return (int)Math.Sqrt(result);
        }

        public static double FindNextSquare(double attemptVal, Skew s)
        {
            double newVal = attemptVal;
            Skew newSkew = Skew.None;
            double square = 0;
            if (!IsSquare(newVal, out square))
            {
                double decimalValue = GetDecimalValue(square);
                newSkew = GetSkewFromDecimal(decimalValue);

                if (newSkew == Skew.Greater)
                    newVal--;
                else
                    newVal++;

                newVal = FindNextSquare(newVal, newSkew);
            }

            return newVal;
        }

        public static double GetDecimalValue(double i)
        {
            return i - Math.Truncate(i);
        }

        public static Skew GetSkewFromDecimal(double d)
        {
            if (d > 0.5)
                return Skew.Lesser;
            if (d < 0.5)
                return Skew.Greater;

            // if it goes this far, the number coming in must be 0.5. As long as
            // we're passing in whole numbers this shouldn't ever get here

            return Skew.None;
        }

        public enum Skew
        {
            None,
            Lesser,
            Greater
        }
    }
}
