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
        public static void Main(string[] args)
        {
            String inputString = Convert.ToString(long.MaxValue);
            char[] charArray = inputString.ToCharArray();
            int[] target = new int[10];

            for (int i = 0; i < charArray.Length; i++)
            {
                int next = Convert.ToInt32(new String(charArray[i], 1));
                target[next]++;
            }

            //What is the highest value for frequency we could have?
            int j = (Convert.ToString(long.MaxValue)).Length;

            //Build up output string
            var sb = new System.Text.StringBuilder();
            sb.Append("[");

            //Control comma appearence
            int valuesWritten = 10;

            for (; j > -1; j--)
            {
                for (int k = 0; k <= 9; k++)
                {
                    if (target[k] == j)
                    {
                        String comma = valuesWritten != 1? "," : "";
                        String found = String.Format("{0} => {1}{2} ", k, j, comma);
                        sb.Append(found);
                        valuesWritten--;
                    }
                }
            }
            sb.Append("]");
            System.Console.WriteLine(sb);
        }
    }
}
