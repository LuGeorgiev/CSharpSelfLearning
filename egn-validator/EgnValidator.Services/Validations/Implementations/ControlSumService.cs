using System;
using System.Linq;

namespace EgnValidator.Services.Validations.Implementations
{
    public class ControlSumService : IControlSumService
    {
        private readonly int[] weight = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

        public bool IsSumValid(string egn)
        {
            var tokens = egn.ToCharArray()
                .Select(x => Int32.Parse(x.ToString()))
                .ToArray();

            var controlSum = 0;
            for (int i = 0; i < 9; i++)
            {
                controlSum += tokens[i] * weight[i];
            }

            var controlBit = controlSum % 11;
            controlBit = controlBit == 10 
                            ? 0 
                            : controlBit;

            if (controlBit != tokens[9])
            {
                return false;
            }

            return true;    
        }
    }
}
