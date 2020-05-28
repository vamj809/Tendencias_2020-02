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
            int romanLength = romanNumber.Length;
            int result = 0;

            //Por cada letra del numero romano
            for (int i = 0; i < romanLength; i++) {
                //Lee valor de la letra actual.
                romanChars.TryGetValue(romanNumber[i], out int curr_val);
                //Verifica que es valido
                if (curr_val == 0)
                    return -1;
                //si (tiene una letra a la derecha)
                if (i < romanLength - 1) {
                    //Lee el siguiente valor.
                    romanChars.TryGetValue(romanNumber[i + 1], out int next_val);
                    //Verifica que es valido
                    if (next_val == 0)
                        return -1;
                    //Si el siguiente valor es mayor al actual, sus valores van juntos.
                    if (next_val > curr_val) {
                        result += next_val - curr_val;
                        i++;
                    }
                    //De otro modo, se suma normalmente
                    else {
                        result += curr_val;
                    }
                }
                //Si es el ultimo valor, solo suma su valor.
                else { 
                    result += curr_val;
                }
            }
            return result;
        }

        static string RomanToArab(string romanNumber = null)
        {
            if (string.IsNullOrEmpty(romanNumber)) {
                Console.Write("Escriba el numero en romano: ");
                romanNumber = Console.ReadLine().Trim();
            } else {
                Console.WriteLine($"Para el numero romano: {romanNumber}");
            }

            int arabic = getRomanValue(romanNumber);

            if (arabic < 1) {
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
            while (true) {
                Console.WriteLine(RomanToArab());
            }
        }
    }
}
