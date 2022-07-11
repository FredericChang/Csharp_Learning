using System.Collections.Generic;

namespace _0013_Roman
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            
        }

        public int RomanTOInt(string s)
        {
            int sum = 0;

            Dictionary<char, int> romanNumber = new()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000},
            };

            for ( int i = 0; i < s.Length; i++)
            {
                char currentRomanChar = s[i];
                romanNumber.TryGetValue(currentRomanChar, out int num);
                if (i + 1 < s.Length && romanNumber[s[i + 1]] > romanNumber[currentRomanChar])
                {
                    sum -= num;
                }
                else
                {
                    sum += num;
                }
            }
            
            return sum;
        }
    }
}