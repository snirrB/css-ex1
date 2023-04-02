using System;

namespace EX01_01
{
    public class Program
    {
        private const int k_binaryNumberLength = 8;
        private const int k_AmountOfNumberToGetFromUser = 3;

        public static void Main()
        {
            printStatisticsOf3Numbers();
            Console.WriteLine("Press any key to exit ....");
            Console.ReadLine();
        }

        public static void printStatisticsOf3Numbers()
        {
            int[] decimalNumbers = new int[k_AmountOfNumberToGetFromUser];
            int sumOfOnes = 0;
            int sumOfZeroz = 0;
            int currentOnesSum;
            int validNumbersCount = 0;
            string binarySequence;

            Console.WriteLine(">>Please enter an 8-bit binary number and press enter");
            while (validNumbersCount != k_AmountOfNumberToGetFromUser)
            {
                Console.Write($">>Number {validNumbersCount + 1}: ");
                binarySequence = Console.ReadLine();
                decimalNumbers[validNumbersCount] = convertBinarySequenceToDecimal(binarySequence, out bool isValid);
                if (isValid)
                {
                    currentOnesSum = countOnesInBinaryNumber(binarySequence);
                    sumOfOnes += currentOnesSum;
                    sumOfZeroz += k_binaryNumberLength - currentOnesSum;
                    validNumbersCount++;
                }
                else
                {
                    Console.WriteLine("Invalid input please type again");
                }
            }

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("-----------------Statistics-------------------------");
            printDecimalNumbersInDecreaseOrder(decimalNumbers);
            Console.WriteLine($"The avarge count of 1s in numbers: {(float) sumOfOnes / k_AmountOfNumberToGetFromUser}");
            Console.WriteLine($"The avarge count of 0s in numbers: {(float) sumOfZeroz / k_AmountOfNumberToGetFromUser}");
            Console.WriteLine($"Count of numbers disivable by 4: {calculateNumberOfNumsDevisableBy4(decimalNumbers)}");
            Console.WriteLine(
                $"Count of numbers with decreasing digits: {countNumbersWithDeacreasingSeriesDigits(decimalNumbers)}");
            Console.WriteLine($"Count of palindrom numbers: {countPalindromNumbers(decimalNumbers)}");
        }

        private static int convertBinarySequenceToDecimal(string i_binarySequence, out bool o_isValid)
        {
            int decimalNumber = 0;
            int currentBit;

            o_isValid = i_binarySequence.Length == k_binaryNumberLength;
            if (o_isValid)
            {
                o_isValid = true;
                for(int i = i_binarySequence.Length - 1, power = 0; i >= 0; --i, ++power)
                {
                    currentBit = i_binarySequence[i] - '0';
                    if(currentBit != 0 && currentBit != 1)
                    {
                        o_isValid = false;
                        break;
                    }
                    decimalNumber += (int)(currentBit * Math.Pow(2, power));
                }
            }

            return decimalNumber;
        }

        private static int countOnesInBinaryNumber(string i_binarySequence)
        {
            int onesCount = 0;
            int currentBit;

            for(int i = 0; i < i_binarySequence.Length; ++i)
            {
                currentBit = i_binarySequence[i] - '0';
                onesCount += currentBit;
            }

            return onesCount;
        }

        private static int converToDecimalAndCount1Bits(string i_binarySequence, out int o_numberOfOnes, out bool o_isValid)
        {
            int decimalNumber = 0;
            int currentBit;

            o_numberOfOnes = 0;
            o_isValid = i_binarySequence.Length == 8;

            if (o_isValid)
            {
                for (int i = i_binarySequence.Length - 1, power = 0; i >= 0; --i, ++power)
                {
                    currentBit = i_binarySequence[i] - '0';
                    if (currentBit == 0 || currentBit == 1)
                    {
                        o_numberOfOnes += currentBit;
                        decimalNumber += (int)(currentBit * Math.Pow(2, power));
                    }
                    else
                    {
                        o_isValid = false;
                        break;
                    }
                }
            }

            return decimalNumber;
        }

        private static void printDecimalNumbersInDecreaseOrder(int[] numbers)
        {
            Array.Sort(numbers);
            Array.Reverse(numbers);
            string messege = string.Format("This are the binary numbers converted to decimal : {0}, {1}, {2}", numbers[0], numbers[1], numbers[2]);
            Console.WriteLine(messege);
        }

        private static int calculateAverageOfOnes(int[] i_countOfOnesPerNum)
        {
            int sumOfOnes = 0;

            for (int i = 0; i < i_countOfOnesPerNum.Length; ++i)
            {
                sumOfOnes += i_countOfOnesPerNum[i]; 
            }

            return sumOfOnes / i_countOfOnesPerNum.Length;
        }

        private static int calculateNumberOfNumsDevisableBy4(int[] i_numbers)
        {
            int numberOfNumsDividedBy4 = 0;

            for (int i = 0; i < i_numbers.Length; ++i) 
            {
                numberOfNumsDividedBy4 += i_numbers[i] % 4 == 0 ? 1 : 0;
            } 

            return numberOfNumsDividedBy4;
        }

        private static int countNumbersWithDeacreasingSeriesDigits(int[] i_numbers)
        {
            int sumOfDecreasingDigits = 0;

            for (int i = 0; i < i_numbers.Length; ++i)
            {
                sumOfDecreasingDigits += isNumberHasDecreasingDigits(i_numbers[i]) ? 1 : 0;
            } 

            return sumOfDecreasingDigits;
        }

        private static bool isNumberHasDecreasingDigits(int i_number)
        {
            bool isDigitDecreasing = true;
            int digit;

            if (i_number < 10)
            {
                isDigitDecreasing = true;
            }

            while (i_number >= 10 && isDigitDecreasing)
            {
                digit = i_number % 10;
                i_number /= 10;
                if (digit >= i_number % 10)
                {
                    isDigitDecreasing = false;
                } 
            }

            return isDigitDecreasing;
        }

        private static int countPalindromNumbers(int[] i_numbers)
        {
            int numOfPalindromes = 0;

            for (int i = 0; i < i_numbers.Length; ++i) 
            {
                numOfPalindromes += isPalindrom(i_numbers[i]) ? 1 : 0;
            } 

            return numOfPalindromes;
        }

        private static bool isPalindrom(int i_number)
        {
            int originalNumber = i_number;
            int reversedNumber = 0;
            int remainder;

            while (i_number > 0)
            {
                remainder = i_number % 10;
                reversedNumber = (reversedNumber * 10) + remainder;
                i_number /= 10;
            }

            return originalNumber == reversedNumber;
        }
    }
}
