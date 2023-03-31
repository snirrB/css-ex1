using System;

namespace EX01_05
{
    public class Program
    {
        public static void Main()
        {
            string sixDigitInAStrgin = getSixDigitInAStringFromUser();
            int counterDigitsGreaterThenUnitsDigit = countDigitsGreaterThenUnitsDigit(sixDigitInAStrgin);
            int smallestDigit = findSmallestDigit(sixDigitInAStrgin);
            int counterDigitsDivisibaleBy3 = countDigitsDivisibaleBy3(sixDigitInAStrgin);
            float avgerDigits = calculateAvgerDigits(sixDigitInAStrgin);
            string newLine = Environment.NewLine;

            string formatString = string.Format(
                                                "nember of digits that larger then the units digit: {0}{4}"
                                                + "the smallest digit: {1}{4}"
                                                + "nember of digits that divisible by 3: {2}{4}"
                                                + "the digits average: {3}",
                                                counterDigitsGreaterThenUnitsDigit,
                                                smallestDigit,
                                                counterDigitsDivisibaleBy3,
                                                avgerDigits,
                                                newLine);

            Console.WriteLine(formatString);
        }

        private static string getSixDigitInAStringFromUser()
        {
            bool isValidInput = false;
            string input = string.Empty;
            
            while (!isValidInput)
            {
                Console.Write("Please enter a six digits number: ");
                input = Console.ReadLine();
                
                if (input.Length == 6)
                {
                    for (int i = 0; i < input.Length; ++i)
                    {
                        if (!char.IsDigit(input[i]))
                        {
                            isValidInput = false;
                            Console.WriteLine("Error - invalid input - Please enter only numbers");
                            break;
                        }

                        isValidInput = true;
                    }
                }
                else 
                { 
                Console.WriteLine("Error - invalid input - more then 6 digits string");
                }
            }

            return input;
        }

        private static int countDigitsGreaterThenUnitsDigit(string i_number)
        {
            int greaterDigitsCounter = 0;
            int stringLength = i_number.Length;
            int unitisDigit = (i_number[stringLength - 1] - '0') % 10;

            for (int i = stringLength - 2; i >= 0; --i)
            {
                greaterDigitsCounter += i_number[i] - '0' > unitisDigit ? 1 : 0;
            }

            return greaterDigitsCounter;
        }

        private static int findSmallestDigit(string i_number)
        {
            int smallestDigit = i_number[0] - '0';
            int currentDigit;

            for (int i = 1; i < i_number.Length; ++i)
            {
                currentDigit = i_number[i] - '0';
                smallestDigit = currentDigit < smallestDigit ? currentDigit : smallestDigit; 
            }

            return smallestDigit;
        }

        private static int countDigitsDivisibaleBy3(string i_number)
        {
            int divisiableBy3Counter = 0;
            char currentStringDigit;
            int currentDigit;

            for (int i = 0; i < i_number.Length; ++i)
            {
                currentStringDigit = i_number[i];
                currentDigit = currentStringDigit - '0';
                divisiableBy3Counter += currentDigit % 3 == 0 ? 1 : 0;
            }

            return divisiableBy3Counter;
        }

        private static float calculateAvgerDigits(string i_number)
        {
            int sumOfDigits = 0;
            char currentStringDigit;
            int currentDigit;
            float average;

            for (int i = 0; i < i_number.Length; ++i)
            {
                currentStringDigit = i_number[i];
                currentDigit = currentStringDigit - '0';
                sumOfDigits += currentDigit;
            }

            average = sumOfDigits / (float)i_number.Length;

            return average;
        }
    }
}
