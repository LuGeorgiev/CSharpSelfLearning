using System.Collections.Generic;

namespace Tests.Infrastructure.Contarcts
{
    public interface IFilterDiagnostics
    {
        IEnumerable<string> Messages { get; }

        void AddMessage(string message);
    }
}
