using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.Services.Infrastructure
{
    public interface IDateTimeProvider
    {
        DateTime BgNow();

        DateTime UtcNow();
    }
}
