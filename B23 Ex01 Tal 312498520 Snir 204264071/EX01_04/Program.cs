using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX01_04
{
    public class Program
    {
        public static void Main()
        {
            AnalyzeStrings();
        }

        public static void AnalyzeStrings()
        {
            string userInput = getAndValidateString(out bool isNumbers);
            bool isStrinPalindrom = isPalindrom(userInput);
            string isPalidromMessege =
                isStrinPalindrom ? "The current string is palindrom" : "The current string is not a palindrom";
            Console.WriteLine(isPalidromMessege);
            if (isNumbers)
            {
                bool isDivisbaleBy3 = isNumberAndIsDivisbaleBy3(userInput);
                string isNumberDivisbaleBy3Answer = isDivisbaleBy3
                    ? "The current string is a number divisable by 3"
                    : "The current string is not a number divisable by 3";
                Console.WriteLine(isNumberDivisbaleBy3Answer);
            }
            else
            {
                int countOfUpperLetters = countUpperLetters(userInput);
                string countOfUpperLettersAnswer =
                    string.Format("There are {0} upper letters in this string", countOfUpperLetters);
                Console.WriteLine(countOfUpperLettersAnswer);
            }
        }

        private static string getAndValidateString(out bool o_isNumbers)
        {
            bool isLetters;
            bool isValid = false;
            string input = string.Empty;
            o_isNumbers = false;

            while (!isValid)
            {
                Console.Write("Please enter a string of 6 letters length:");
                input = Console.ReadLine();
                if (input.Length == 6)
                {
                    isLetters = isContainsLetters(input);
                    o_isNumbers = isContainsNumbers(input);
                    isValid = (!isLetters && o_isNumbers) || (isLetters && !o_isNumbers);
                }

                if (!isValid)
                {
                    Console.WriteLine("Error please enter a string of length 6 combine from only letters or numbers");
                }
            }

            return input;
        }

        private static bool isContainsLetters(string i_input)
        {
            bool isContainsLetters = true;

            for (int i = 0; i < i_input.Length; ++i)
            {
                isContainsLetters = isContainsLetters && char.IsLetter(i_input[i]);
            }

            return isContainsLetters;
        }

        private static bool isContainsNumbers(string i_input)
        {
            bool isContainsNumbers = true;

            for (int i = 0; i < i_input.Length; ++i)
            {
                isContainsNumbers = isContainsNumbers && char.IsDigit(i_input[i]);
            }

            return isContainsNumbers;
        }

        private static bool isPalindrom(string i_string)
        {
            int stringlength = i_string.Length;
            if (stringlength <= 1)
            {
                return true;
            }

            string stringWithoutEdges = i_string.Substring(1, stringlength - 2);

            return i_string[0] == i_string[stringlength - 1] && isPalindrom(stringWithoutEdges);
        }

        private static bool isNumberAndIsDivisbaleBy3(string i_input)
        {
            bool isDivisbale = false;
            bool isNumber = int.TryParse(i_input, out int number);

            if (isNumber && number % 3 == 0)
            {
                isDivisbale = true;
            }

            return isDivisbale;
        }

        private static int countUpperLetters(string i_input)
        {
            int upperLetterCounter = 0;

            for (int i = 0; i < i_input.Length; ++i)
            {
                upperLetterCounter += char.IsUpper(i_input[i]) ? 1 : 0;
            }

            return upperLetterCounter;
        }
    }
}
