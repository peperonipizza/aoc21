using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    public class Day_7
    {
        public void part1()
        {
            int[] a = File.ReadAllText(@"C:\Users\julia\source\repos\advent\advent\inputs\inputday7.txt")
                        .Split(",").Select(int.Parse).ToArray();
            int min = a.Min(), max = a.Max();
            int p1 = Enumerable.Range(min, max - min + 1).Select(pos => a
                    .Select(x => Math.Abs(pos - x)).Sum()).Min();
            Console.WriteLine(p1);
        }

        public void part2()
        {
            int[] a = File.ReadAllText(@"C:\Users\julia\source\repos\advent\advent\inputs\inputday7.txt")
                        .Split(",").Select(int.Parse).ToArray();
            int min = a.Min(), max = a.Max();
            int p2 = Enumerable.Range(min, max - min + 1).Select(pos => a
                    .Select(x => Math.Abs(pos - x))
                    .Select(x => x * (x + 1) / 2).Sum()).Min();
            Console.WriteLine(p2);
        }
    }

}
