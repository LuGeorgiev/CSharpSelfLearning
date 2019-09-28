using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.Services.Validations
{
    public interface IFutureDate
    {
        bool IsDateInFuture(DateTime date);
    }
}
