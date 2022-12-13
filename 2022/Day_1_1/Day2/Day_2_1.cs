using Days;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day2
{
    public class Day_2_1 : IDay //11603
    {
        public string Path { get; set; } = "..\\..\\Day2\\source1.txt";

        public List<char> opponentVariants = new List<char>();
        public List<char> myVariants = new List<char>();

        public string GetAnswer()
        {
            var text = FileReader.GetTextFromFile(Path);

            ReadVariantsFromText(text);

            return GetGameScore().ToString();
        }

        public int GetGameScore()
        {
            int score = 0;
            int scoreForWin = 0;

            for (int i = 0; i < opponentVariants.Count; i++)
            {
                if (myVariants[i] == 'Y')
                {
                    score += 2;

                    if (opponentVariants[i] == 'A')
                    {
                        scoreForWin += 6;
                    }
                    else if (opponentVariants[i] == 'B')
                    {
                        scoreForWin += 3;
                    }
                    else if (opponentVariants[i] == 'C')
                    {
                        scoreForWin += 0;
                    }
                }

                if (myVariants[i] == 'X') // rock
                {
                    score += 1;

                   if (opponentVariants[i] == 'A') // Rock
                    {
                        scoreForWin += 3;
                    }
                    else if (opponentVariants[i] == 'B') // Paper
                    {
                        scoreForWin += 0;
                    }
                    else if (opponentVariants[i] == 'C') //sciccor
                    {
                        scoreForWin += 6;
                    }
                }

                if (myVariants[i] == 'Z') // sciccors
                {
                    score += 3;
                    if (opponentVariants[i] == 'A') // Rock
                    {
                        scoreForWin += 0;
                    }
                    else if (opponentVariants[i] == 'B') // Paper
                    {
                        scoreForWin += 6;
                    }
                    else if (opponentVariants[i] == 'C') //sciccor
                    {
                        scoreForWin += 3;
                    }
                }
            }

            return score + scoreForWin;
        }

        public void ReadVariantsFromText(string[] text)
        {
            foreach (var line in text)
            {
                var charComb = line.Split(' ');
                opponentVariants.Add(charComb[0][0]);
                myVariants.Add(charComb[1][0]);
            }
        }
    }
}