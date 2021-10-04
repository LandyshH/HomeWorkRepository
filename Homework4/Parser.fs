module Homework4.Parser

open System
let TryParseOperationOrQuit (arg: string, operation: outref<CalculatorOperation>) =
    operation <- match arg with
    | "+" -> CalculatorOperation.Plus
    | "-" -> CalculatorOperation.Minus
    | "*" -> CalculatorOperation.Multiply
    | "/" -> CalculatorOperation.Divide
    | _ -> enum<CalculatorOperation>(0)
    
    operation <> enum<CalculatorOperation>(0);;        
let CheckArgLength (args: string[]) =
    args.Length = 3;;

let TryParseArgOrQuit (arg: string, _val: outref<int>) =   
    Int32.TryParse(arg, &_val);;
    
let ParseArguments(args: string[], val1: outref<int>, operation: outref<CalculatorOperation>, val2: outref<int> ) =
    if CheckArgLength args = false then HundledExceptions.WrongArgLength
    elif TryParseOperationOrQuit(args.[1], &operation) = false then HundledExceptions.WrongOperation
    elif TryParseArgOrQuit(args.[0], &val1) = false || TryParseArgOrQuit(args.[2], &val2) = false then HundledExceptions.WrongArgFormatInt
    else HundledExceptions.Success
     
      