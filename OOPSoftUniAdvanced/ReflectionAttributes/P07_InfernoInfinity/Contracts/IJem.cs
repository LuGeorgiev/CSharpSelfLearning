using P07_InfernoInfinity.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Contracts
{
    public interface IJem
    {
        int Strength { get; }
        int Agility { get; }
        int Vitality { get; }
        Clarity JemClarity { get; }
    }
}
