using System;
using System.Globalization;
using JetBrains.Annotations;

namespace Calculator
{
    internal static class Program
    {
        private enum Operator
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            Power,
        }

        private static void Main()
        {
            Console.WriteLine("Welcome to Calculator. Please enter your calculation.");
            Console.WriteLine();

            decimal operand1 = ReadNumber("Number 1");
            Operator @operator = ReadOperator("Operator");
            decimal operand2 = ReadNumber("Number 2");

            decimal result;

            switch (@operator)
            {
                case Operator.Add:
                    result = RunAdd(operand1, operand2);
                    break;

                case Operator.Subtract:
                    result = RunSubtract(operand1, operand2);
                    break;

                case Operator.Divide:
                    result = RunDivide(operand1, operand2);
                    break;
                    
                case Operator.Multiply:
                    result = RunMultiply(operand1, operand2);
                    break;
                
                case Operator.Power:
                    result = RunPower(operand1, operand2);
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine($"ERROR: Operator '{@operator}' is not yet implemented.");
                    return;
            }

            Console.WriteLine();
            Console.WriteLine("Result: " + result.ToString(CultureInfo.InvariantCulture));
        }

        [Pure]
        private static decimal RunAdd(decimal operand1, decimal operand2)
        {
            return operand1 + operand2;
        }

        [Pure]
        private static decimal RunSubtract(decimal operand1, decimal operand2)
        {
            return operand1 - operand2;
        }

        [Pure]
        private static decimal RunDivide(decimal operand1, decimal operand2)
        {
            return (operand2 == 0) ? return 100000 : return operand1/operand2;
        }

        [Pure]
        private static decimal RunMultiply(decimal operand1, decimal operand2)
        {
            return operand1*operand2;
        }

        [Pure]
        private static decimal RunPower(decimal operand1, decimal operand2)
        {
            return Pow(operand1, operand2);
        }

        [Pure]
        private static decimal ReadNumber([NotNull] string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                string line = Console.ReadLine();
                if (decimal.TryParse(line, NumberStyles.Any, CultureInfo.InvariantCulture, out var number))
                {
                    return number;
                }

                Console.WriteLine($"ERROR: '{line}' is not a number.");
            }
        }

        [Pure]
        private static Operator ReadOperator([NotNull] string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                string line = Console.ReadLine();

                switch (line?.Trim())
                {
                    case "+":
                        return Operator.Add;

                    case "-":
                        return Operator.Subtract;

                    case "*":
                        return Operator.Multiply;

                    case "/":
                        return Operator.Divide;
                }

                Console.WriteLine($"ERROR: '{line}' is not a valid operation. Only + - * / are supported.");
            }
        }

    }
}
