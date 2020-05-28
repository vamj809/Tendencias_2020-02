using System;
using System.Collections.Generic;

namespace A03_RomanToArabic
{
    class Program
    {
        /*
         * IDEA (Algoritmo): Lee un numero romano.
         * Por cada letra del número romano, valida que la letra existe...
         * SI el valor siguiente es mayor al valor actual, entonces se combinan sus valores (2do-1ro)
         * SI NO, se agrega el valor que tiene.
         */

        static Dictionary<char, int> romanChars = new Dictionary<char, int>{
            {'M', 1000},
            {'D',  500},
            {'C',  100},
            {'L',   50},
            {'X',   10},
            {'V',    5},
            {'I',    1}
        };

        static int getRomanValue(string romanNumber)
        {
            romanNumber = romanNumber.ToUpper();
            int romanLength = romanNumber.Length;
            int result = 0;

            for (int i = 0; i < romanLength; i++) {
                romanChars.TryGetValue(romanNumber[i], out int curr_val);
                if (curr_val == 0)
                    return -1;

                if (i < romanLength - 1) {

                    romanChars.TryGetValue(romanNumber[i + 1], out int next_val);
                    if (next_val == 0)
                        return -1;

                    if (next_val > curr_val) {
                        result += next_val - curr_val;
                        i++;
                    }
                    else {
                        result += curr_val;
                    }
                }
                else { 
                    result += curr_val;
                }
            }
            return result;
        }

        static string RomanToArab(string romanNumber = null) {

            if (string.IsNullOrEmpty(romanNumber)) {
                Console.Write("Escriba el numero en romano: ");
                romanNumber = Console.ReadLine().Trim();
            } else {
                Console.WriteLine($"Para el numero romano: {romanNumber}");
            }

            int arabic = getRomanValue(romanNumber);

            if (arabic < 0) {
                return "Numero no es valido.";
            }
            else {
                return "Valor Arabico: " + arabic;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(RomanToArab("MMXVIII"));
            Console.WriteLine(RomanToArab("MMXX"));
            Console.WriteLine(RomanToArab("MMXX"));

            while (true) {
                Console.WriteLine("------------------ Type [END] to finish program ------------------");
                Console.Write("Escriba el numero en romano: ");
                string romanNumber = Console.ReadLine().Trim();

                if (romanNumber.ToUpper() == "END")
                    break;

                int arabic = getRomanValue(romanNumber);
                if (arabic < 0) {
                    Console.WriteLine("Numero no es valido.");
                }
                else {
                    Console.WriteLine("Valor Arabico: " + arabic);
                }
            }
        }
    }
}
