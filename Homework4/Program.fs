module Homework4.Program
 
[<EntryPoint>]
let Main(args: string[]) =
    let val1, operation, val2  = Parser.ParseArguments(args)    
    let result = Calculator.Calculate val1 operation val2
    printfn($"Answer is: {result}")
    0