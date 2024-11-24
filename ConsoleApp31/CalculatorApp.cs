

namespace ConsoleApp31
{

    public class CalculatorException : Exception
    {
        public string Status { get; }

        public CalculatorException(string message, string status) : base(message)
        {
            Status = status;
        }
    }
}