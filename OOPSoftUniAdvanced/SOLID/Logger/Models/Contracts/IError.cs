using System;

namespace Logger.Models.Contracts
{
    public interface IError:ILevalable
    {
        DateTime DateTime { get; }

        string Message { get; }
        
    }
}