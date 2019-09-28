using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.Services.Infrastructure
{
    public interface IExtractDate
    {
        DateTime? TryExtractDate(string dateString);
    }
}
