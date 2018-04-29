using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.Models
{
    public class LogFile : ILogFile
    {
        const string DefaulPath = "./date/";

        public LogFile(string filename)
        {
            this.Path = DefaulPath + filename;
            InitializeFile();
            this.Size = 0;
        }

        private void InitializeFile()
        {
            Directory.CreateDirectory(DefaulPath);
            File.AppendAllText(this.Path, "");
        }

        public string Path { get; }

        public int Size { get; private set; }

        public void WriteToFile(string errorLog)
        {
            File.AppendAllText(this.Path, errorLog+Environment.NewLine);

            int addedSize = 0;
            for (int i = 0; i < errorLog.Length; i++)
            {
                addedSize += errorLog[i];
            }
            this.Size += addedSize;
        }
    }
}
