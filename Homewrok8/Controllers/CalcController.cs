using System;
using Homewrok8.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace Homewrok8.Controllers
{
    public class CalcController : Controller
    {
        public string Calculate([FromServices] ICalculator calc, string val1, string op, string val2)
        {
            var val1IsDouble = double.TryParse(val1, out var value1);
            var val2IsDouble = double.TryParse(val2, out var value2);

            if (!val1IsDouble || !val2IsDouble) return "Wrong parameter";
            return op switch
            {
                "Plus" => calc.Add(value1, value2),
                "Minus" => calc.Minus(value1, value2),
                "Divide" => calc.Divide(value1, value2),
                "Multiply" => calc.Multiply(value1, value2),
                _ => "Wrong operation"
            };
        }
    }
}