module Homework4.Calculator
let Calculate (val1: int) (operation: CalculatorOperation) (val2: int) =
    match operation with
    | CalculatorOperation.Plus -> val1 + val2
    | CalculatorOperation.Multiply -> val1 * val2
    | CalculatorOperation.Minus -> val1 - val2
    | _ -> val1 / val2
