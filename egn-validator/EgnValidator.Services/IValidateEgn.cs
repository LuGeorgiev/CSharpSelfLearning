using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.Services
{
    public interface IValidateEgn
    {
        string IsValid(string egn);
    }
}
