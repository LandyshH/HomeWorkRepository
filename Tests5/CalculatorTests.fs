module Tests.CalculatorTests

open Homework5
open Xunit

[<Theory>]
[<InlineData(9, 3, CalculatorOperation.Plus, 12)>]
[<InlineData(9, 3, CalculatorOperation.Minus,  6)>]
[<InlineData(9, 3, CalculatorOperation.Divide, 3)>]
[<InlineData(6, 3, CalculatorOperation.Multiply, 18)>]
[<InlineData(9.4, 3.6, CalculatorOperation.Plus, 13)>]
[<InlineData(9.6, 3.2, CalculatorOperation.Divide, 3)>]
[<InlineData(9.62341, 3.21, CalculatorOperation.Minus, 6.41341)>]
[<InlineData(9.6266, 4, CalculatorOperation.Divide, 2.40665)>]
[<InlineData(8.4646, 9, CalculatorOperation.Multiply, 76.1814)>]

let CalculatorTest_Calculate (val1, val2, operation, expected) =
    let actual = decimal (Calculator.Calculate(val1, operation, val2))
    Assert.Equal(expected, actual, 10)
   
    
    
