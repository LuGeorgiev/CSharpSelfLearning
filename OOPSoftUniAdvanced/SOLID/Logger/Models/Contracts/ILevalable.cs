using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface ILevalable
    {
        ErrorLevel Level { get; }
    }
}
