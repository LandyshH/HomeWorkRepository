using System.Globalization;

namespace Homewrok8.Calculator
{
    public class Calculator : ICalculator
    {
        public string Add(double val1, double val2)
        {
            return (val1 + val2).ToString(CultureInfo.InvariantCulture);
        }

        public string Multiply(double val1, double val2)
        {
            return (val1 * val2).ToString(CultureInfo.InvariantCulture);
        }

        public string Divide(double val1, double val2)
        {
            return val2 == 0 ? "Infinity" : (val1 / val2).ToString(CultureInfo.InvariantCulture);
        }

        public string Minus(double val1, double val2)
        {
            return (val1 - val2).ToString(CultureInfo.InvariantCulture); 
        }
    }
}