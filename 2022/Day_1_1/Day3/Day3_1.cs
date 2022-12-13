using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days.Day3
{
    public class Day3_1 : IDay
    {
        public string Path { get; set; } = "..\\..\\Day3\\source1.txt";

        public string GetAnswer()
        {
            var text = File.ReadAllLines(Path);

            int score = 0;

            foreach (var line in text)
            {
                var firstPart = ConvertLineToIntArray(line, 0, line.Length / 2);
                var secondPart = ConvertLineToIntArray(line, line.Length / 2, line.Length / 2);

                score += firstPart.FirstOrDefault(x => secondPart.Contains(x));
            }

            return score.ToString();
        }

        public int[] ConvertLineToIntArray(string line, int startIndex, int substringLength)
        {
            var charDic = GetCharDictionary();

            return line.Trim().Substring(startIndex, substringLength).ToCharArray()
                .Select(x => charDic.ElementAt(charDic.IndexOfKey(x)).Value)
                .OrderBy(x => x)
                .Distinct()
                .ToArray();
        }

        public SortedList<char, int> GetCharDictionary()
        {
            var dictionary = new SortedList<char, int>();

            for (int i = 97; i < 97 + 26; i++)
            {
                dictionary.Add((char) i, i - 96);
            }

            for (int i = 65; i < 65 + 26; i++)
            {
                dictionary.Add((char) i, i - 38);
            }

            return dictionary;
        }
    }
}