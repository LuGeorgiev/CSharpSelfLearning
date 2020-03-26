using System.Collections.Generic;
using Tests.Infrastructure.Contarcts;

namespace Tests.Infrastructure
{
    public class DefaultFilterDiagnostics : IFilterDiagnostics
    {
        private List<string> messages = new List<string>();

        public IEnumerable<string> Messages 
            => this.messages;

        public void AddMessage(string message)
            => this.messages.Add(message);
    }
}
