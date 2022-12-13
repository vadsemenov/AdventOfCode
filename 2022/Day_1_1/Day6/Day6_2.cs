using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days.Day6
{
    public class Day6_2: IDay
    {
        public string Path { get; set; } = "..\\..\\Day6\\source1.txt";

        public string GetAnswer()
        {
            var text = File.ReadAllText(Path).Trim().ToCharArray();

            var marker = GetPackageIndexBruteForce(text);

            return marker.ToString();
        }

        //Brute Force
        private static int GetPackageIndexBruteForce(char[] line)
        {
            var charPackage = new List<char>();

            for (int i = 0; i < line.Length - 13; i++)
            {
                charPackage.Clear();

                for (int j = i; j < 14+i; j++)
                {
                    charPackage.Add(line[j]);
                }

                if (charPackage.Distinct().Count() == 14)
                {
                    return i + 13 + 1;
                }
            }

            return -1;
        }
    }
}