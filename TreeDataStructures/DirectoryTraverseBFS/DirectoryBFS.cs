using System;
using System.Collections.Generic;
using System.IO;

namespace DirectoryTraverseBFS
{
    public static class DirectoryBFS
    {
        public static void TraverseDir(string dirPath)
        {
            Queue<DirectoryInfo> visitedDirsQueue = new Queue<DirectoryInfo>();
            visitedDirsQueue.Enqueue(new DirectoryInfo(dirPath));

            while (visitedDirsQueue.Count>0)
            {
                DirectoryInfo currentDir = visitedDirsQueue.Dequeue();
                Console.WriteLine(currentDir.FullName);

                DirectoryInfo[] children = currentDir.GetDirectories();
                foreach (DirectoryInfo child in children)
                {
                    visitedDirsQueue.Enqueue(child);
                }
            }
        }


        static void Main(string[] args)
        {
            TraverseDir(@"C:\ORDERS");
        }
    }
}
