namespace Homework4

type CalculatorProblem (val1: int, operation: CalculatorOperation, val2: int) =
    member this.Val1 = val1
    member this.Val2 = val2
    member this.Operation = operation
    new() = CalculatorProblem(0, CalculatorOperation.Plus, 0)
