using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraverse
{
    class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            var filesDictionary = new Dictionary<string, List<FileInfo>>();

            var files = Directory.GetFiles(path);            

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var extension = fileInfo.Extension;

                if (!filesDictionary.ContainsKey(extension))
                {
                    filesDictionary[extension] = new List<FileInfo>();
                }
                filesDictionary[extension].Add(fileInfo);
            }

            filesDictionary = filesDictionary
                .OrderBy(x => x.Value.Count)
                .ThenBy(x => x.Key)                
                .ToDictionary(x => x.Key, y => y.Value);

            string deskop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullFileName = deskop + "/report.txt";

            using (var writer  =new StreamWriter(fullFileName))
            {
                foreach (var pair in filesDictionary)
                {
                    string extension = pair.Key;
                    var fileInfos = pair.Value
                        .OrderByDescending(fl=>fl.Length);

                    writer.WriteLine(extension);
                    foreach (var fileInfo in fileInfos)
                    {
                        double fileSize = (double)fileInfo.Length / 1024;
                        writer.WriteLine($"--{fileInfo.Name} - {fileSize:f2}kb");
                    }
                }
            }
        }
    }
}
