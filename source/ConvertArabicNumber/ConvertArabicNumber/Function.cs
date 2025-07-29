using System;

namespace ConvertArabicNumber
{
    internal class Function
    {
        public static bool isInt(String number)
        {
            int i;

            return Int32.TryParse(number, out i);
        }
        public static bool isDouble(String number)
        {
            Double i;

            return Double.TryParse(number, out i);
        }
		
        public static string getDoubleDecimalSeparator()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        }
    }
}