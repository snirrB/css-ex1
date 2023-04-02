using System;

namespace EX01_02
{
    public class Program
    {
        private const int k_diamnodHight = 9;

        public static void Main()
        {
            PrintDiamond(k_diamnodHight);
            Console.WriteLine("Press any key to exit ...");
            Console.ReadLine();
        }

        public static void PrintDiamond(int i_dianmondHight, int i_currentRow = 1)
        {
            if (i_dianmondHight % 2 == 0)
            {
                i_dianmondHight--;
            }

            int numberOfStarsToPrint = i_currentRow + (i_currentRow - 1);
            int numberOfSpacesToPrint = (i_dianmondHight - numberOfStarsToPrint) / 2;
            printChararcterForLength(' ', numberOfSpacesToPrint);
            printChararcterForLength('*', numberOfStarsToPrint);
            Console.WriteLine();
            if (i_currentRow * 2 > i_dianmondHight)
            {
                return;
            }
            else
            {
                PrintDiamond(i_dianmondHight, ++i_currentRow);
            }

            printChararcterForLength(' ', numberOfSpacesToPrint);
            printChararcterForLength('*', numberOfStarsToPrint);
            Console.WriteLine();
        }

        private static void printChararcterForLength(char i_character, int i_length)
        {
            for (int i = 0; i < i_length; ++i)
            {
                Console.Write(i_character);
            }
        }
    }
}
