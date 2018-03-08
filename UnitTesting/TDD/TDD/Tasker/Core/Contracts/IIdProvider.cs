using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.Core.Contracts
{
    public interface IIdProvider
    {
        int NextId();
    }
}
