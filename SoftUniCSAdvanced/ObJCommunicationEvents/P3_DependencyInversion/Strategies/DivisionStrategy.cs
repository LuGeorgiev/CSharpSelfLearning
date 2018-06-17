using P3_DependencyInversion.Contracts;

namespace P3_DependencyInversion.Strategies
{
    public class DivisionStrategy : ICalculationStrategy
    {
        public int Calculate(int first, int second)
        {
            return first / second;
        }
    }
}
