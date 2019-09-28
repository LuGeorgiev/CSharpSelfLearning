using System;
using System.IO;

namespace EgnValidator.Services.Infrastructure.Implementations
{
    class FileReader : IReader
    {
        private readonly StreamReader reader;

        public FileReader(string contents)
        {
            this.reader = new StreamReader(new System.IO.FileStream(contents, FileMode.Open, FileAccess.Read & FileAccess.Write));
        }

        public string ReadLine() => this.reader.ReadLine();
    }
}
