using P3_DependencyInversion;
using P3_DependencyInversion.Strategies;
using P3_DependencyInversion.Contracts;
using System;

namespace P3_DependencyInversion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator(new AdditionStrategy());

            string input;

            while ((input=Console.ReadLine())!="End")
            {
                string[] tokens = input.Split();
                string firstArg = tokens[0];

                if (firstArg=="mode")
                {
                    char @operator = tokens[1][0];
                    ICalculationStrategy strategy=null;

                    if (@operator == '+')
                    {
                        strategy = new AdditionStrategy();
                    }
                    else if (@operator == '-')
                    {
                        strategy = new SubtractionStrategy();
                    }
                    else if (@operator == '/')
                    {
                        strategy = new DivisionStrategy();
                    }
                    else if (@operator == '*')
                    {
                        strategy = new MultiplicationStrategy();
                    }

                    if (strategy==null)
                    {
                        throw new ArgumentException("Invalid mode");
                    }

                    calculator.ChangeStrategy(strategy);
                }
                else
                {
                    int firstOperand = int.Parse(tokens[0]);
                    int secondOperand = int.Parse(tokens[1]);

                    int result = calculator.PerformCalculation(firstOperand, secondOperand);

                    Console.WriteLine(result);
                }
            }
        }
    }
}
