module Homework6.Parser
open Homework6
open InputProblem
let TryParseOperationInput (problem:InputProblem) =
    match problem.Operation with
    | "Plus" -> Ok CalculatorOperation.Plus
    | "Multiply" -> Ok CalculatorOperation.Multiply
    | "Minus" -> Ok CalculatorOperation.Minus
    | "Divide" -> Ok CalculatorOperation.Divide
    | _ -> Error "Wrong operation."  