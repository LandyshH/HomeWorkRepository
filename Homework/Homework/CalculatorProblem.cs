namespace HomeWork
{
    public class CalculatorProblem
    {
        public int Val1 { get; }
        public int Val2 { get; }
        public CalculatorOperation Operation { get; }

        public CalculatorProblem(int val1, CalculatorOperation operation, int val2)
        {
            Val1 = val1;
            Operation = operation;
            Val2 = val2;
        }

        public CalculatorProblem()
        { }
    }
}