using System;
using System.IO;

namespace DirectoryTraverserDFS
{
    public static class DirectoryDFS
    {
        private static void TraverseDir(DirectoryInfo dir, string spaces)
        {
            Console.WriteLine(spaces + dir.FullName);
            DirectoryInfo[] children = dir.GetDirectories();

            foreach (DirectoryInfo child in children)
            {
                TraverseDir(child, spaces + " ");
            }
        }

        public static void TraverseDir(string directoryPath)
        {
            TraverseDir(new DirectoryInfo(directoryPath), string.Empty);
        }  
    

        public static void Main()
        {
            TraverseDir(@"C:\ORDERS");
        }
    }
}
