using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Contracts
{
    public interface IJemFactory
    {
        IJem CreateJem(string jemType, string jemClarity);
    }
}
