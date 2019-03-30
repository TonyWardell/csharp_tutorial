using System;

// We need to create a simple routine that calculates the frequency of the digits
// in an 8 byte number, the result needs to be sorted by the frequency.
// For example: Long.MAX_VALUE = 9,223,372,036,854,775,807
//The frequency is:
//[7 => 4, 2 => 3, 3 => 3, 0 => 2, 5 => 2, 8 => 2, 4 => 1, 6 => 1, 9 => 1, 1 =>0]
//This exercise should be done in a IDE and should take less than 30 mins.

namespace csharp_tutorial
{
    public class Program
    {
        private const int INDEX_FOR_BASE10_ARRAY = 9;

        public static void Main(string[] args)
        {
            int[] frequencies = CalculateFrequencies(long.MaxValue);
            int potentialFreq = CalculateHighestPotentialFreq();
            System.Text.StringBuilder result = PopulateResultWithFrequencies(frequencies, potentialFreq);
            DecorateResult(result);
            Console.WriteLine(result);
        }

        private static int[] CalculateFrequencies(long value)
        {
            int[] numberSequence = SplitInputNumberIntoArrayOfNumbers(value);
            int[] frequencies = new int[10];
            for (int i = 0; i < numberSequence.Length; i++)
            {
                frequencies[numberSequence[i]]++;
            }
            return frequencies;
        }

        //What is the highest value for frequency we could have?
        private static int CalculateHighestPotentialFreq()
        {
            return (Convert.ToString(long.MaxValue)).Length;
        }

        private static System.Text.StringBuilder PopulateResultWithFrequencies(int[] frequencies, int potentialFreq)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (; potentialFreq > -1; potentialFreq--)
            {
                for (int number = 0; number <= INDEX_FOR_BASE10_ARRAY; number++)
                {
                    if (frequencies[number] == potentialFreq)
                    {
                        OutputFrequency(potentialFreq, sb, number);
                    }
                }
            }
            return sb;
        }

        private static void DecorateResult(System.Text.StringBuilder sb)
        {
            sb.Insert(0, "[");
            sb.Append("]");
        }

        private static void OutputFrequency(int freq, System.Text.StringBuilder sb, int number)
        {
            String commaAndTrailingSpace = number != 1 ? ", " : "";
            String numberFrequency = String.Format("{0} => {1}{2}", number, freq, commaAndTrailingSpace);
            sb.Append(numberFrequency);
        }

        private static int[] SplitInputNumberIntoArrayOfNumbers(long value)
        {
            String inputString = Convert.ToString(value);
            char[] charArray = inputString.ToCharArray();
            int[] numberSequence = new int[charArray.Length];
            for (int i = 0; i < charArray.Length; i++)
            {
                int numberAtIndex = Convert.ToInt32(new String(charArray[i], 1));
                numberSequence[i] = numberAtIndex;
            }
            return numberSequence;
        }
    }
}
