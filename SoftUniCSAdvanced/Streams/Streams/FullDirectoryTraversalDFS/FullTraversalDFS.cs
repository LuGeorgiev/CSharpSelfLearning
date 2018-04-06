using System;
using System.IO;

namespace FullDirectoryTraversalDFS
{
    class FullTraversalDFS
    {
        static void Main(string[] args)
        {
            TravetsDir(@"C:\Development\CSharpSelfLearning\Recursion");
        }

        private static void TravetsDir(string path)
        {
            TraversDir(new DirectoryInfo(path), "*");
           
        }

        private static void TraversDir(DirectoryInfo directory, string asterix)
        {
            Console.WriteLine(asterix + directory.FullName);
            var files = directory.GetFiles();
            foreach (var file in files)
            {
                var fileName = file.FullName;
                Console.WriteLine(new string('-',asterix.Length+1)+fileName);
            }            

            var subDirectories = directory.GetDirectories();
            foreach (var subDir in subDirectories)
            {
                TraversDir(subDir, asterix + "*");
            }
        }
    }
}
