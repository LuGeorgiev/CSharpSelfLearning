using P3_DependencyInversion.Contracts;

namespace P3_DependencyInversion.Strategies
{
	public class SubtractionStrategy:ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
