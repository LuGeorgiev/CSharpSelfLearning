using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Core.Providers.Contract
{
    public interface IIdProvider
    {
        int NextId();
    }
}
