using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_Group2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] words = {"blueBerry", "Chimpanzee", "abacus", "banana", "apple", "cheese"};
            string[] words2 = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese", "elephant", "umbrella", "anteater" };

            var wordGroups = from w in words group w by w[0];
            foreach (var wordGroup in wordGroups)
            {
                Console.WriteLine("Words that start with the letter '{0}':", wordGroup.Key);
                foreach (var word in wordGroup)
                {
                    Console.WriteLine(word);
                }
            }

            var wordGroups2 = from w in words2
                group w by w[0]
                into grps
                where (grps.Key == 'a' || grps.Key == 'i' || grps.Key == 'e' || grps.Key == 'o' || grps.Key == 'u')
                select grps;
            foreach (var wordGroup in wordGroups2)
            {
                Console.WriteLine("Groups that start with a vowel: {0}", wordGroup.Key);
                foreach (var word in wordGroup)
                {
                    Console.WriteLine("   {0}", word);
                }
            }

        }
    }
}