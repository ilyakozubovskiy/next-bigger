using System;

namespace NextBiggerTask
{
    public static class NumberExtension
    {
        /// <summary>
        /// Finds the nearest largest integer consisting of the digits of the given positive integer number and null if no such number exists.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>
        /// The nearest largest integer consisting of the digits  of the given positive integer and null if no such number exists.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when source number is less than 0.</exception>
        public static int? NextBiggerThan(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number is less than 0", nameof(number));
            }

            if (number == int.MaxValue)
            {
                return null;
            }

            int length = 1;
            decimal numberDecimal = number;

            while ((numberDecimal /= 10) >= 1)
            {
                length++;
            }

            int[] digitArray = new int[length];

            for (int i = 1, num = number; num > 0; num /= 10, i++)
            {
                digitArray[^i] = num % 10;
            }

            for (int i = digitArray.Length - 1; i > 0; i--)
            {
                if (digitArray[i] > digitArray[i - 1])
                {
                    int tmp = digitArray[i];
                    digitArray[i] = digitArray[i - 1];
                    digitArray[i - 1] = tmp;
                    Array.Sort(digitArray, i, digitArray.Length - i);
                }

                int res = 0;
                for (int j = 0; j < digitArray.Length; j++)
                {
                    res = (10 * res) + digitArray[j];
                }

                if (res > number)
                {
                    return res;
                }
            }

            return null;
        }
    }
}
