using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.Text.RegularExpressions;


namespace advent
{
    public class Day_5
    {
        private static string[] data = File.ReadAllLines(@"C:\Users\julia\source\repos\advent\advent\inputs\inputday5.txt");

        // 2d array of big map so all vents fit
        private int[][] seaMap = Enumerable.Range(0, 1000).Select(x => new int[1000]).ToArray(); 

        private void addVents(int x1, int y1, int x2, int y2)
        {
            int dx = (x1 == x2 ? 0 : Math.Sign(x2 - x1));
            int yx = (y1 == y2 ? 0 : Math.Sign(y2 - y1));

            while (!(x1 == x2 && y1 == y2))
            {
                seaMap[x1][y1]++;
                x1 += dx;
                y1 += yx;
            }

            seaMap[x1][y1]++;
        }

        public void part1and2()
        {
            // part 1
            foreach (string line in data)
            {
                int[] nums = Regex.Matches(line, @"(\d+)").Select(x => int.Parse(x.Value)).ToArray();
                if (nums[0] == nums[2] || nums[1] == nums[3])
                    addVents(nums[0], nums[1], nums[2], nums[3]);
            }
            Console.WriteLine(seaMap.Aggregate(0, (sum, row) => (sum + row.Where(n => n > 1).Count())));

            // part 2
            foreach (string line in data)
            {
                int[] nums = Regex.Matches(line, @"(\d+)").Select(x => int.Parse(x.Value)).ToArray();
                if (!(nums[0] == nums[2] || nums[1] == nums[3]))
                    addVents(nums[0], nums[1], nums[2], nums[3]);
            }
            Console.WriteLine(seaMap.Aggregate(0, (sum, row) => (sum + row.Where(n => n > 1).Count())));
        }
    }
}
