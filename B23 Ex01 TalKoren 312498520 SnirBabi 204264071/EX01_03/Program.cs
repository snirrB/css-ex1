using System;

namespace EX01_03
{
    public class Program
    {
        public static void Main()
        {
            printDiamondOfStartsSetByUser();
        }

        private static void printDiamondOfStartsSetByUser()
        {
            int diamondHight = getDiamnodHightFromUser();
            EX01_02.Program.PrintDiamond(diamondHight);
            Console.WriteLine("Press any key to exit ...");
            Console.ReadLine();
        }

        private static int getDiamnodHightFromUser()
        {
            bool isValidInput = false;
            int hight = 0;

            Console.Write("Please enter dianmond Hight:");
            while (!isValidInput)
            {
                try
                {
                    hight = int.Parse(Console.ReadLine());
                    if (hight <= 0)
                    {
                        Console.WriteLine("Please enter only number greater than 1");
                        Console.Write("Please enter again dianmond Hight:");
                    }
                    else
                    {
                        isValidInput = true;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Error - input is null\nPlease enter a value before pressing 'Enter'");
                    Console.Write("Please enter again dianmond Hight:");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error - input contains non numeric values\nPlease enter only numeric values");
                    Console.Write("Please enter again dianmond Hight:");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error - input out of range\nPlease enter only positive integer under 2^32");
                    Console.Write("Please enter again dianmond Hight:");
                }
            }

            return hight;
        }
    }
}
