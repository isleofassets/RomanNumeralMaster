using System;
using System.Collections.Generic;

namespace RomanNumeralMaster
{
    public static class RomanConverter
    {
        public static int MIN_VALUE = 1, MAX_VALUE = 3999;

        private static readonly string[] SYMBOLS = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        private static readonly int[] VALUES = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

        private static readonly Dictionary<char, int> NUMERALS = new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };

        /// <summary>
        /// Check if a given string is a valid Roman numeral.
        /// </summary>
        /// <param name="romanNumber"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static bool IsRoman(string romanNumber, bool ignoreCase = false)
        {
            if (!ignoreCase)
                romanNumber = romanNumber.ToUpper();
            for (int i = 0; i < romanNumber.Length; i++)
                if (!NUMERALS.ContainsKey(romanNumber[i]))
                    return false;
            return true;
        }

        /// <summary>
        /// Convert a decimal number to a Roman numeral.
        /// </summary>
        /// <param name="decimalNumber"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string ConvertToRoman(int decimalNumber)
        {
            if (decimalNumber < MIN_VALUE || decimalNumber > MAX_VALUE)
                throw new ArgumentOutOfRangeException("The number must be from " + MIN_VALUE + " to " + MAX_VALUE + ".");
            string result = "";
            for (int i = 0; i < SYMBOLS.Length; i++)
            {
                while (decimalNumber >= VALUES[i])
                {
                    result += SYMBOLS[i];
                    decimalNumber -= VALUES[i];
                }
            }
            return result;
        }

        /// <summary>
        /// Converts the string representation of a 32-bit signed integer to its Roman number equivalent. A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="decimalNumber"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryConvertToRoman(int decimalNumber, out string result)
        {
            result = "";
            if (decimalNumber < MIN_VALUE || decimalNumber > MAX_VALUE)
                return false;
            for (int i = 0; i < SYMBOLS.Length; i++)
            {
                while (decimalNumber >= VALUES[i])
                {
                    result += SYMBOLS[i];
                    decimalNumber -= VALUES[i];
                }
            }
            return true;
        }

        /// <summary>
        /// Convert a Roman numeral to a decimal number.
        /// </summary>
        /// <param name="romanNumber"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int ConvertToDecimal(string romanNumber, bool ignoreCase = false)
        {
            if (!ignoreCase)
                romanNumber = romanNumber.ToUpper();
            int result = 0;
            for (int i = 0; i < romanNumber.Length; i++)
            {
                if (!NUMERALS.ContainsKey(romanNumber[i]))
                    throw new ArgumentException("An incorrect Roman number has been entered.");
                if (i + 1 < romanNumber.Length && NUMERALS[romanNumber[i + 1]] > NUMERALS[romanNumber[i]])
                    result -= NUMERALS[romanNumber[i]];
                else
                    result += NUMERALS[romanNumber[i]];
            }
            return result;
        }

        /// <summary>
        /// Converts the string representation of a Roman number to its 32-bit signed integer equivalent. A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="romanNumber"></param>
        /// <param name="result"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static bool TryConvertToDecimal(string romanNumber, out int result, bool ignoreCase = false)
        {
            if (!ignoreCase)
                romanNumber = romanNumber.ToUpper();
            result = 0;
            for (int i = 0; i < romanNumber.Length; i++)
            {
                if (!NUMERALS.ContainsKey(romanNumber[i]))
                    return false;
                if (i + 1 < romanNumber.Length && NUMERALS[romanNumber[i + 1]] > NUMERALS[romanNumber[i]])
                    result -= NUMERALS[romanNumber[i]];
                else
                    result += NUMERALS[romanNumber[i]];
            }
            return true;
        }
    }
}