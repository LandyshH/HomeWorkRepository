module Homework5.Calculator
let Calculate (val1: decimal, operation: CalculatorOperation, val2: decimal) =
    match operation with
    | CalculatorOperation.Plus -> val1 + val2
    | CalculatorOperation.Multiply -> val1 * val2
    | CalculatorOperation.Minus -> val1 - val2
    | _ -> val1 / val2
