using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    public class Day_6
    {
        public List<int> lanternfishList = Array.ConvertAll(File.ReadAllLines(@"C:\Users\julia\source\repos\advent\advent\inputs\inputday6.txt")[0].Split(","), int.Parse).ToList();
        public void part1(int days)
        {
            int day = 0;
            while (day < days)
            {
                List<int> newFishList = new(lanternfishList);
                int newfishcounter = 0;
                int fishindex = 0;
                foreach (int fishtimer in lanternfishList)
                {
                    if (fishtimer == 0)
                    {
                        newFishList[fishindex] = 6;
                        newfishcounter++;
                    }
                    else
                    {
                        newFishList[fishindex]--;
                    }
                    fishindex++;
                }
                for (int x = 1; x <= newfishcounter; x++)
                {
                    newFishList.Add(8);
                }
                lanternfishList = new(newFishList);
                day++;
            }
            Console.WriteLine(lanternfishList.Count);
        }

        public void part2(int days)
        {
            List<int> lanternfishList2 = Array.ConvertAll(File.ReadAllLines(@"C:\Users\julia\source\repos\advent\advent\inputs\inputday6.txt")[0].Split(","), int.Parse).ToList();
            Dictionary<string, long> fishGroups = new()
            {
                { "Day0", 0 },
                { "Day1", 0 },
                { "Day2", 0 },
                { "Day3", 0 },
                { "Day4", 0 },
                { "Day5", 0 },
                { "Day6", 0 },
                { "Day7", 0 },
                { "Day8", 0 },
                { "Day9", 0 },
            };

            foreach (int fishTimer in lanternfishList2)
            {
                switch (fishTimer)
                {
                    case (0):
                        fishGroups["Day0"]++;
                        break;
                    case (1):
                        fishGroups["Day1"]++;
                        break;
                    case (2):
                        fishGroups["Day2"]++;
                        break;
                    case (3):
                        fishGroups["Day3"]++;
                        break;
                    case (4):
                        fishGroups["Day4"]++;
                        break;
                    case (5):
                        fishGroups["Day5"]++;
                        break;
                    case (6):
                        fishGroups["Day6"]++;
                        break;
                    case (7):
                        fishGroups["Day7"]++;
                        break;
                    case (8):
                        fishGroups["Day8"]++;
                        break;
                }
            }

            for (int day = 1; day <= days; day++)
            {
                for (int groupIndex = 0; groupIndex < fishGroups.Count; groupIndex++)
                {
                    fishGroups["Day9"] = fishGroups["Day0"];
                    fishGroups["Day0"] = fishGroups["Day1"];
                    fishGroups["Day1"] = fishGroups["Day2"];
                    fishGroups["Day2"] = fishGroups["Day3"];
                    fishGroups["Day3"] = fishGroups["Day4"];
                    fishGroups["Day4"] = fishGroups["Day5"];
                    fishGroups["Day5"] = fishGroups["Day6"];
                    fishGroups["Day6"] = fishGroups["Day7"];
                    fishGroups["Day7"] = fishGroups["Day8"];
                    fishGroups["Day8"] = fishGroups["Day9"];
                    fishGroups["Day9"] = 0;
                }
                fishGroups["Day6"] += fishGroups["Day8"];
            }
            Console.WriteLine(fishGroups["Day0"] + fishGroups["Day1"] + fishGroups["Day2"] + fishGroups["Day3"] + fishGroups["Day4"] + fishGroups["Day5"] + fishGroups["Day6"] + fishGroups["Day7"] + fishGroups["Day8"]);
        }
    }
}
