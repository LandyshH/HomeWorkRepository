module Tests.CalculatorTests

open Homework5
open Xunit

[<Theory>]
[<InlineData(9, 3, CalculatorOperation.Plus, 12)>]
[<InlineData(9, 3, CalculatorOperation.Minus,  6)>]
[<InlineData(9, 3, CalculatorOperation.Divide, 3)>]
[<InlineData(6, 3, CalculatorOperation.Multiply, 18)>]
let CalculatorTest_Calculate_int (val1: int, val2: int, operation, expected: int) =
    let actual = Calculator.Calculate(val1, operation, val2)
    Assert.Equal(expected, actual)
    
    
[<Theory>]
[<InlineData(9.0009, 3.0001, CalculatorOperation.Plus, 12.001)>]
[<InlineData(5.35389, 3, CalculatorOperation.Minus,  2.35389)>]
[<InlineData(9.9609, 3.2, CalculatorOperation.Divide, 3.11278125)>]
[<InlineData(2.491, 6.84, CalculatorOperation.Multiply, 17.03844)>]   
let CalculatorTest_Calculate_decimal (val1: decimal, val2:decimal, operation, expected: decimal) =
    let actual = Calculator.Calculate(val1, operation, val2)
    Assert.Equal(expected, actual, 28)

[<Theory>]
[<InlineData(9.9, 3.1, CalculatorOperation.Plus, 13)>]
[<InlineData(9.31, 2.56, CalculatorOperation.Minus,  6.75)>]
[<InlineData(9.6, 3, CalculatorOperation.Divide, 3.2)>]
[<InlineData(56.64, 7.8, CalculatorOperation.Multiply, 441.792)>]
let CalculatorTest_Calculate_double (val1: double, val2: double, operation, expected: double) =
    let actual = Calculator.Calculate(val1, operation, val2)
    Assert.Equal(expected, actual, 15)

[<Theory>]
[<InlineData(9.66666, 3.23, CalculatorOperation.Plus, 12.89666)>]
[<InlineData(9.234, 3.12, CalculatorOperation.Minus,  6.114)>]
[<InlineData(15.455, 5.5, CalculatorOperation.Divide, 2.81)>]
[<InlineData(13.5142, 3, CalculatorOperation.Multiply, 40.5426)>]    
let CalculatorTest_Calculate_float (val1: float, val2: float, operation, expected: float) =
    let actual = Calculator.Calculate(val1, operation, val2)
    Assert.Equal(expected, actual, 9)