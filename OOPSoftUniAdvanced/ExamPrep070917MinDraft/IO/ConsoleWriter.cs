using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ConsoleWriter : IWriter
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}
    

