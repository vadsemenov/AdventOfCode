using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days.Day4
{
    public class Day4_1 : IDay
    {
        public string Path { get; set; } = "..\\..\\Day4\\source1.txt";

        public string GetAnswer()
        {
            return File.ReadAllLines(Path).Select(CheckSetSubset).Sum().ToString();
        }

        public static int CheckSetSubset(string line)
        {
            var elfesPair = line.Trim().Split(',');

            var elfes1Numbers = elfesPair[0].Trim().Split('-').Select(int.Parse).ToArray();
            var elfes2Numbers = elfesPair[1].Trim().Split('-').Select(int.Parse).ToArray();

            var elfe1Set = GetSetFromArrayLimits(elfes1Numbers);
            var elfe2Set = GetSetFromArrayLimits(elfes2Numbers);

            if (elfe1Set.IsSubsetOf(elfe2Set) || elfe2Set.IsSubsetOf(elfe1Set))
            {
                return 1;
            }

            return 0;
        }

        public static HashSet<int> GetSetFromArrayLimits(int[] hashsetLimits)
        {
            var result = new HashSet<int>();

            for (int i = hashsetLimits[0]; i <= hashsetLimits[1]; i++)
            {
                result.Add(i);
            }

            return result;
        }
    }
}