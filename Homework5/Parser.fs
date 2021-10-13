module Homework5.Parser

open System
let TryParseOperationOrQuit (val1: decimal, op: string, val2: decimal) =
    match op with
        |"+" -> Ok (val1, CalculatorOperation.Plus, val2)
        | "-" -> Ok (val1, CalculatorOperation.Minus, val2)
        | "*" -> Ok (val1, CalculatorOperation.Multiply, val2)
        | "/" -> Ok (val1, CalculatorOperation.Divide, val2)
        | _ -> Error HundledExceptions.WrongOperation
    
    
type MaybeBuilder() =
    member b.Bind(x, foo) =
        match x with
        | Ok y -> foo y
        | Error n -> Error n
    member b.Return x = Ok x
let maybe = MaybeBuilder()

let CheckArgLength (args: string[]) =
    match args.Length with
    | 3 -> Ok args
    | _ -> Error HundledExceptions.WrongArgLength

let TryParseArgOrQuit (args: string[]) =
    try
        Ok (args.[0] |> decimal, args.[1], args.[2] |> decimal)
    with
        | _ -> Error HundledExceptions.WrongArgFormat

let ParseArguments(args: string[]) =
    maybe{
        let! temp = CheckArgLength args
        let! temp2 = TryParseArgOrQuit temp
        let! result = TryParseOperationOrQuit temp2
        return result
    }
   
   