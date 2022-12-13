using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days.Day7
{
    public class Day7_2 : IDay
    {
        public string Path { get; set; } = "..\\..\\Day7\\source1.txt";

        public string GetAnswer()
        {
            var text = File.ReadAllLines(Path);

            var treeRootNode = CreateTree(text);

            GetFoldersSize(treeRootNode);

            var freeSpace = 70_000_000 - folderFilesSize.Max(x => x.Item2);
            var neededFreeSpace = 30_000_000;

            var folderSizeForDelete = folderFilesSize
                .Where(x => x.Item2 >= neededFreeSpace - freeSpace)
                .OrderBy(x => x.Item2)
                .Select(x => x.Item2)
                .FirstOrDefault();

            return folderSizeForDelete.ToString();
        }

        public static List<(string, int)> folderFilesSize = new List<(string, int)>();

        public static int GetFoldersSize(TreeNode treeNode)
        {
            var filesSize = treeNode.Files.Sum(x => x.Item2);

            foreach (var node in treeNode.Folders)
            {
                filesSize += GetFoldersSize(node);
            }

            folderFilesSize.Add((treeNode.DirName, filesSize));

            return filesSize;
        }

        private TreeNode CreateTree(string[] text)
        {
            var rootNode = new TreeNode();
            rootNode.DirName = "/";

            var currentNode = rootNode;

            for (int i = 1; i < text.Length; i++)
            {
                var lineSplit = text[i].Split(' ');

                if (text[i].StartsWith(@"$ cd .."))
                {
                    if (currentNode.ParentDir != null)
                    {
                        currentNode = currentNode.ParentDir;
                    }
                }
                else if (text[i].StartsWith(@"$ cd"))
                {
                    currentNode = currentNode.Folders.FirstOrDefault(x => x.DirName == lineSplit[2]);
                }
                else if (text[i].StartsWith(@"$ ls"))
                {
                }
                else if (text[i].StartsWith(@"dir"))
                {
                    currentNode.Folders.Add(new TreeNode() {ParentDir = currentNode, DirName = lineSplit[1]});
                }
                else
                {
                    currentNode.Files.Add((lineSplit[1], int.Parse(lineSplit[0])));
                }
            }

            return rootNode;
        }
    }
}