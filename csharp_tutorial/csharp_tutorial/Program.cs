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
            int greatestPotentialFrequency = CalculateHighestPotentialFreq(long.MaxValue);
            String formattedFrequencies = FormatFrequencies(frequencies, greatestPotentialFrequency);
            String complete = DecorateResult(formattedFrequencies);
            Console.WriteLine(complete);
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
        private static int CalculateHighestPotentialFreq(long value)
        {
            return (Convert.ToString(value)).Length;
        }

        private static String FormatFrequencies(int[] frequencies, int greatestPotentialFrequency)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int testFreq = greatestPotentialFrequency; testFreq > -1; testFreq--)
            {
                String formattedFreqs = FormateFrequenciesForTestFrequency(frequencies, testFreq);
                sb.Append(formattedFreqs);
            }
            return sb.ToString();
        }

        private static String FormateFrequenciesForTestFrequency(int[] frequencies, int testFreq)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int number = 0; number <= INDEX_FOR_BASE10_ARRAY; number++)
            {
                if (NumberHasFrequency(frequencies, testFreq, number))
                {
                    String formattedFrequency = FormatFrequencyUsage(testFreq, number);
                    sb.Append(formattedFrequency);
                }
            }
            return sb.ToString();
        }

        private static bool NumberHasFrequency(int[] frequencies, int testFreq, int number)
        {
            return frequencies[number] == testFreq;
        }

        private static String DecorateResult(String formattedFrequencies)
        {
            return String.Format("[{0}]", formattedFrequencies);
        }

        private static String FormatFrequencyUsage(int freq, int number)
        {
            String commaAndTrailingSpace = number != 1 ? ", " : "";
            return String.Format("{0} => {1}{2}", number, freq, commaAndTrailingSpace);
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

/*
 * This program aims to demonstrate the following good coding practicies
 * ---------------------------------------------------------------------
 * Methods have an abstraction at the same level
 * 
 * Method names are clear and show intent
 * 
 * Methods only do one thing - and do it well ;)
 * 
 * Method argument lists are short
 * 
 * Methods don't modify the state of arguments they receive (no side affects)
 * 
 * Methods are idempotent
 * 
 * Variable names are clear and show intent
 * 
 * Functionality is not spread across the code e.g. DecorateResult
 * 
 * Avoid Magic Numbers
 * 
 * This code has the following problems however
 * --------------------------------------------
 * 
 * It uses statics too much
 * 
 * Its purely procedural, not OO
*/
