using System.Collections.Generic;

namespace Homework10.StringExtensions
{
    public static class StringExtensions
    {
        public static IEnumerable<string> ParseBySpace(this string expression)
        {
            return expression.Split();
        }
        
        public static bool IsOperation(this string arg)
        {
            return arg is "+" or "-" or "/" or "*";
        }
    }
}