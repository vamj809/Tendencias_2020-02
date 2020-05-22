using System;
using System.Collections.Generic;

namespace A03_RomanToArabic
{
    class Program
    {
        /*
         * https://www.comeausoftware.com/2018/03/convert-roman-arabic-numerals-csharp/
         * https://gist.github.com/ajcomeau/fdd46f8ee87f30944e3524d2d8181c36
         * Start with the first letter of the string (C = 100).
         * If the letter after that (D = 500) is worth more than the first one, 
         *  subtract the value of the first letter from the second and add the result to the return value.
         *  
         *  (i.e. “CD”:  500 (D) – 100 (C) = 400).
         *  
         *  If the next letter is worth less according to the dictionary, 
         *  just add the value of the current letter to the return value.
         *  
         *  Repeat the process.*/
        Dictionary<char, int> romanChars = new Dictionary<char, int>{
            {'M', 1000},
            {'D',  500},
            {'C',  100},
            {'L',   50},
            {'X',   10},
            {'V',    5},
            {'I',    1}
        };
        static void Main(string[] args)
        {
            //Roman to Arabic
            Console.WriteLine("Hello World! XD");
        }
    }
}
