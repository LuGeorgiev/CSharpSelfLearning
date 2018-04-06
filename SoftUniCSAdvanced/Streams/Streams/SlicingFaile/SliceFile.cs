using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace SlicingFaile
{
    
    class Program
    {
        private const int bufSize= 4096;
        static void Main(string[] args)
        {
            string path = @"../../../sliceMe.mp4";
            string destination = @"../../../Destination/";

            //Slice(path, destination, 5);

            Zip(path, destination, 5);

            var files = new List<string>
            {
               destination+ "Part-0.mp4",
               destination+ "Part-1.mp4",
               destination+ "Part-2.mp4",
               destination+ "Part-3.mp4",
               destination+ "Part-4.mp4",
            };
            Assemble(files,destination);
            if (File.Exists(path))
            {
                Console.WriteLine("found");
            }

            
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {

            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.')+1);
                long piceSize =(long)Math.Ceiling( (double)reader.Length / parts);
                

                for (int i = 0; i < parts; i++)
                {
                    destinationDirectory = destinationDirectory == string.Empty ? "./" : destinationDirectory;
                    string currentPart = destinationDirectory + $"Part-{i}.{extension}";
                    long currentPiceSize = 0;

                    using (var writer = new FileStream(currentPart, FileMode.CreateNew))
                    {
                        byte[] buffer = new byte[bufSize];
                        while (reader.Read(buffer,0, bufSize)== bufSize)
                        {
                            writer.Write(buffer, 0, bufSize);
                            currentPiceSize += bufSize;
                            if (currentPiceSize>=piceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.') + 1);

            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = @"../../..";
            }
            if (!destinationDirectory.EndsWith("/"))
            {
                destinationDirectory += "/";
            }

            string assembledFile = $"{destinationDirectory}Assembled.{extension}";
            using (FileStream writer = new FileStream(assembledFile, FileMode.Create))
            {
                byte[] buffer = new byte[bufSize];
                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        while (reader.Read(buffer,0,bufSize)==bufSize)
                        {
                            writer.Write(buffer, 0, bufSize);
                        }
                    }
                }
            }
        }

        static void Zip(string sourceFile, string destinationDirectory, int parts)
        {

            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
                long piceSize = (long)Math.Ceiling((double)reader.Length / parts);


                for (int i = 0; i < parts; i++)
                {
                    destinationDirectory = destinationDirectory == string.Empty ? "./" : destinationDirectory;
                    string currentPart = destinationDirectory + $"Part-{i}.{extension}.gz";

                    
                    long currentPiceSize = 0;
                    using (GZipStream writer = new GZipStream( new FileStream(currentPart, FileMode.CreateNew),CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[bufSize];
                        while (reader.Read(buffer, 0, bufSize) == bufSize)
                        {
                            writer.Write(buffer, 0, bufSize);
                            currentPiceSize += bufSize;
                            if (currentPiceSize >= piceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
