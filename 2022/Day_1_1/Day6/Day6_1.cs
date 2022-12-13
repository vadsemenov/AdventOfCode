using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days.Day6
{
    public class Day6_1 : IDay
    {
        public string Path { get; set; } = "..\\..\\Day6\\source1.txt";

        public string GetAnswer()
        {
            var text = File.ReadAllText(Path).Trim().ToCharArray();

            var marker = GetPackageIndexBruteForce(text);

            return marker.ToString();
        }

        //BrutForce
        private static int GetPackageIndexBruteForce(char[] line)
        {
            var charPackage = new List<char>();

            for (int i = 0; i < line.Length-3; i++)
            {
                charPackage.Clear();

                charPackage.Add(line[i]);
                charPackage.Add(line[i+1]);
                charPackage.Add(line[i+2]);
                charPackage.Add(line[i+3]);

                if (charPackage.Distinct().Count() == 4)
                {
                    return i + 3 + 1;
                }
            }

            return -1;
        }
    }
}