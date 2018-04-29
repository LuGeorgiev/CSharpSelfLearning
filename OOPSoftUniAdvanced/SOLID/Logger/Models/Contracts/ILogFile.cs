using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface ILogFile
    {
        string Path { get; }
        int Size { get; }
        void WriteToFile(string errorLog);
    }
}
