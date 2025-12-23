using WebApplication2.Controllers;

namespace WebApplication2.Models
{
    public class CalculatorLibrary
    {
        public static double CalculateOperation(double number1, double number2, Operation operation)
        {
            return operation switch
            {
                Operation.Add => number1 + number2,
                Operation.Subtract => number1 - number2,
                Operation.Multiply => number1 * number2,
                Operation.Divide => number1 / number2,
                _ => throw new ArgumentOutOfRangeException(nameof(operation), "Invalid operation"),
            };
        }
    }
}
