using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    public class Day_2
    {
        public void part1(string[] d2p1array)
        {
            var depth = 0;
            var horizontalpos = 0;
            foreach (var item in d2p1array)
            {
                var values = item.Split(" ").ToList();
                var change = int.Parse(values[1]);
                switch (values[0])
                {
                    case "forward":
                        horizontalpos += change;
                        break;
                    case "up":
                        depth += change;
                        break;
                    case "down":
                        depth -= change;
                        break;
                }
            }
            Console.WriteLine(Math.Abs(depth) * horizontalpos);
        }

        public void part2(string[] d2p2array)
        {
            var depth2 = 0;
            var horizontalPos2 = 0;
            var aim = 0;
            foreach (var movement in d2p2array)
            {
                var values = movement.Split(' ').ToList();
                var change = int.Parse(values[1]);
                switch (values[0])
                {
                    case "forward":
                        horizontalPos2 += change;
                        depth2 += aim * change;
                        break;
                    case "up":
                        aim -= change;
                        break;
                    case "down":
                        aim += change;
                        break;
                }
            }
            Console.WriteLine(Math.Abs(depth2) * horizontalPos2);
        }
    }
}
