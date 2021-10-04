module Homework4.Program
 
[<EntryPoint>]
let Main(args: string[]) =
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operation = CalculatorOperation.Divide
    let resultIs = Parser.ParseArguments(args, &val1, &operation, &val2)
    if resultIs <> HundledExceptions.Success then int resultIs
    else
       let result = Calculator.Calculate val1 operation val2
       printfn($"Answer is: {result}")
       0