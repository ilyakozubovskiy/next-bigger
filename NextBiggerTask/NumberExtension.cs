using System;
using System.Globalization;

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

            string numberInString = number.ToString(CultureInfo.InvariantCulture);
            int[] digitArray = new int[numberInString.Length];
            for (int i = 0; i < numberInString.Length; i++)
            {
                digitArray[i] = Convert.ToInt32(new string(numberInString[i], 1), new CultureInfo("en-US"));
            }

            for (int i = digitArray.Length - 1; i > 0; i--)
            {
                if (digitArray[i] > digitArray[i - 1])
                {
                    int tmp = digitArray[i];
                    digitArray[i] = digitArray[i - 1];
                    digitArray[i - 1] = tmp;
                    for (int j = i; j < digitArray.Length - 1; j++)
                    {
                        int min = j;
                        for (int k = j + 1; k < digitArray.Length; k++)
                        {
                            if (digitArray[k] < digitArray[min])
                            {
                                min = k;
                            }
                        }

                        int tmp1 = digitArray[min];
                        digitArray[min] = digitArray[j];
                        digitArray[j] = tmp1;
                    }
                }

                int res = 0;
                for (int j = 0; j < digitArray.Length; j++)
                {
                    res += digitArray[j] * Convert.ToInt32(Math.Pow(10, digitArray.Length - j - 1));
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
