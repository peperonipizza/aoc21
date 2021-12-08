using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    public static class Day_1
    {
        static int count1 = 0;
        static int count2 = 0;
        public static void part1(int[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > input[i - 1])
                    count1++;
            }
            Console.WriteLine(count1);
        }

        public static void part2(int[] input)
        {
            for (int i = 0; i + 3 < input.Length; i++)
            {
                int slide1 = input[i] + input[i + 1] + input[i + 2];
                int slide2 = input[i + 1] + input[i + 2] + input[i + 3];
                if (slide1 < slide2)
                    count2++;
            }
            Console.WriteLine(count2);
        }
    }
}
