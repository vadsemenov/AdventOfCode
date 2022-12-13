using System.IO;

namespace Days.Day8
{
    public class Day8_1 : IDay
    {
        public string Path { get; set; } = "..\\..\\Day8\\source1.txt";

        public string GetAnswer()
        {
            var lines = File.ReadAllLines(Path);

            var treeArray = GetTreeArray(lines);

            var highestTreesAmount = GetHighestTrees(treeArray);

            return highestTreesAmount.ToString();
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

        private int GetHighestTrees(int[,] treeArray)
        {
            var columnAmount = treeArray.GetLength(1);
            var rowAmount = treeArray.GetLength(0);

            int highestTreeAmount = 0;

            for (int i = 1; i < rowAmount-1; i++)
            {
                for (int j = 1; j < columnAmount-1; j++)
                {
                    if (IsHighestTree(i, j, treeArray))
                    {
                        highestTreeAmount++;
                    }
                }
            }

            var count = rowAmount * 2 + (columnAmount * 2 - 4);

            highestTreeAmount += count;

            return highestTreeAmount;
        }

        private bool IsHighestTree(int y, int x, int[,] treeArray)
        {
            var value = treeArray[y, x];

            bool isHighest = true;

            for (int i = y + 1; i < treeArray.GetLength(0); i++)
            {
                if (value <= treeArray[i, x])
                {
                    isHighest = false;

                    break;
                }
            }

            if (isHighest)
            {
                return true;
            }

            isHighest = true;

            for (int i = y - 1; i >= 0; i--)
            {
                if (value <= treeArray[i, x])
                {
                    isHighest = false;

                    break;
                }

            }

            if (isHighest)
            {
                return true;
            }

            isHighest = true;

            for (int j = x + 1; j < treeArray.GetLength(1); j++)
            {
                if (value <= treeArray[y, j])
                {
                    isHighest = false;
                    break;
                }
            }

            if (isHighest)
            {
                return true;
            }

            isHighest = true;

            for (int j = x - 1; j >= 0; j--)
            {
                if (value <= treeArray[y, j])
                {
                    isHighest = false;

                    break;
                }
            }

            return isHighest;
        }
    }
}