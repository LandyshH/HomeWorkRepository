module Homework6.Calculator
open Homework6
open InputProblem
let inline Calculate val1 operation val2 =
    match operation with
    | CalculatorOperation.Plus -> val1 + val2
    | CalculatorOperation.Multiply -> val1 * val2
    | CalculatorOperation.Minus -> val1 - val2
    | _ -> val1 / val2