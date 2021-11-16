namespace Homewrok8.Calculator
{
    public interface ICalculator
    {
        string Add(double val1, double val2);
        string Multiply(double val1, double val2);
        string Divide(double val1, double val2);
        string Minus(double val1, double val2);
    }
}