using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days.Day8
{
    public class Day8_2 : IDay
    {
        public string Path { get; set; } = "..\\..\\Day8\\source1.txt";

        public string GetAnswer()
        {
            var lines = File.ReadAllLines(Path);

            var treeArray = GetTreeArray(lines);

            var maxScore = GetMaxScore(treeArray);

            return maxScore.ToString();
        }

        private int[,] GetTreeArray(string[] lines)
        {
            var columnAmount = lines[0].ToCharArray().Length;
            var rowAmount = lines.Length;

            var treeArray = new int[rowAmount, columnAmount];

            for (int i = 0; i < rowAmount; i++)
            {
                var lineChar = lines[i].ToCharArray();

                for (int j = 0; j < columnAmount; j++)
                {
                    treeArray[i, j] = int.Parse(lineChar[j].ToString());
                }
            }

            return treeArray;
        }

        private int GetMaxScore(int[,] treeArray)
        {
            var columnAmount = treeArray.GetLength(1);
            var rowAmount = treeArray.GetLength(0);

            int highestTreeAmount = 0;

            var listScore = new List<int>();

            for (int i = 1; i < rowAmount - 1; i++)
            {
                for (int j = 1; j < columnAmount - 1; j++)
                {
                    listScore.Add(GetTreeScore(i, j, treeArray));
                }
            }

            return listScore.Max();
        }

        private int GetTreeScore(int y, int x, int[,] treeArray)
        {
            var value = treeArray[y, x];

            var treeScores = new List<int>();

            int score = 0;
            for (int i = y + 1; i < treeArray.GetLength(0); i++)
            {
                score += 1;

                if (value <= treeArray[i, x])
                {
                    break;
                }
            }

            treeScores.Add(score);
            score = 0;

            for (int i = y - 1; i >= 0; i--)
            {
                score += 1;

                if (value <= treeArray[i, x])
                {
                    break;
                }
            }

            treeScores.Add(score);
            score = 0;

            for (int j = x + 1; j < treeArray.GetLength(1); j++)
            {
                score += 1;

                if (value <= treeArray[y, j])
                {
                    break;
                }
            }

            treeScores.Add(score);
            score = 0;

            for (int j = x - 1; j >= 0; j--)
            {
                score += 1;

                if (value <= treeArray[y, j])
                {
                    break;
                }
            }

            treeScores.Add(score);

            return treeScores.Aggregate((z, v) => z * v);
        }
    }
}