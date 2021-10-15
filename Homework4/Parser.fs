module Homework4.Parser

open System
let TryParseOperationOrQuit (operation: string) =
     match operation with
     | "+" ->  CalculatorOperation.Plus
     | "-" ->  CalculatorOperation.Minus
     | "*" ->  CalculatorOperation.Multiply
     | "/" ->  CalculatorOperation.Divide
     | _ -> raise (HundledExceptions.WrongOperation("Wrong operation."))
     
           
let CheckArgLength (args: string[]) =
    args.Length = 3
    

let TryParseArgOrQuit (arg: string) =   
   try
     arg |> int
   with
     | _ -> raise (HundledExceptions.WrongArgFormatInt("Wrong argument format"))
    
let ParseArguments(args: string[]) =

    if CheckArgLength args = false then raise (HundledExceptions.WrongArgLength("The program requires 3 arguments."))
    let val1 = TryParseArgOrQuit args.[0]
    let operation = TryParseOperationOrQuit args.[1]
    let val2 = TryParseArgOrQuit args.[2]
    val1, operation, val2
   
    