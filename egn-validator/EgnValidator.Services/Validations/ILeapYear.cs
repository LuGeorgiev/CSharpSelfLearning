using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.Services.Validations
{
    public interface ILeapYear
    {
        bool IsYearLeap(string egn);
    }
}
