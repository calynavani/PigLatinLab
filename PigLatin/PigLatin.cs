using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PigLatin
{
    class PigLatin
    {


        public string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().ToLower().Trim();
            return input;

            
        }


        public bool IsVowel(char c)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            return vowels.Contains(c);
            //the conditional would only return false if being compared to char [] vowels to string aka "aeiou" because no char c will ever be equal to "aeiou"
        }

        //this method will allow for the program to seperate input into different string so that if one string
        //contains special characters, it will still run.
        public string PrintSubString(string word)
        {
            string[] words;

            words = word.Split(' ');
            string newWord = string.Empty;

            foreach (string wd in words)
            {

                newWord += ToPigLatin(wd) + " " ;
           
            }

            return newWord;
           
        }
        
        public string ToPigLatin(string word)
        {
            char[] specialChars = { '@', '.', '-', '$', '^', '&' };
            word = word.ToLower();


            foreach (char c in specialChars)
            {
                foreach (char w in word)
                {
                    if (w == c)
                    {
                        Console.WriteLine("That word has special characters, we will return it as is");
                        return word;
                    }
                }

            }

            bool noVowels =  true;
            foreach (char letter in word)
            {
                if (IsVowel(letter))
                {
                    noVowels = false;
                }
            }

            if (noVowels)
            {
                return word;
            }

            char firstLetter = word[0];
            string output = "placeholder";
            if (IsVowel(firstLetter) == true)
            {
                output = word + "way";
                //needed to add a "w" to "ay"
            }
            else
            {
                int vowelIndex = -1;
                //Handle going through all the consonants
                for (int i = 0; i <= word.Length; i++)
                {
                    if (IsVowel(word[i]) == true)
                    {
                        vowelIndex = i;
                        break;
                    }
                }

                string sub = word.Substring(vowelIndex);
                //this is not supposed to split at the index after the first vowel so we don't need to add 1 to the index
                string postFix = word.Substring(0, vowelIndex);
                //we want this to make a new string with the first letter and stop at the vowel index(first vowel)

                output = sub + postFix + "ay";
            }

            return output;
        }
    }
}

