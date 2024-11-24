// See https://aka.ms/new-console-template for more information
using ConsoleApp31;

class Program
{
    static void Main()
    {
        while (true)
        {
            try
            {

                Console.Write("Enter the first number: ");
                if (!double.TryParse(Console.ReadLine(), out double num1))
                {
                    throw new FormatException("Invalid input! Please enter a valid number.");
                }


                Console.Write("Enter the second number: ");
                if (!double.TryParse(Console.ReadLine(), out double num2))
                {
                    throw new FormatException("Invalid input! Please enter a valid number.");
                }


                Console.Write("Enter the operation (+, -, *, /): ");
                string operation = Console.ReadLine();

               
                double result = Calculate(num1, num2, operation);

                Console.WriteLine($"Result: {result}");


            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division by zero is not allowed! Please try again.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }



        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static double Calculate(double num1, double num2, string operation)
    {
        if (!new[] { "+", "-", "*", "/" }.Contains(operation))
        {
            throw new InvalidOperationException("Invalid operation!");
        }


        if (Math.Abs(num1) > 1000000 || Math.Abs(num2) > 1000000)
        {
            throw new CalculatorException("The numbers are too large!", "NUMBER_TOO_LARGE");
        }

        return operation switch
        {
            "+" => num1 + num2,
            "-" => num1 - num2,
            "*" => num1 * num2,
            "/" => num2 == 0
                    ? throw new DivideByZeroException()
                    : num1 / num2,
            _ => throw new InvalidOperationException("Invalid operation!")
        };
    }
}