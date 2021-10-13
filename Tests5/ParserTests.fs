module Tests.ParserTests

open Homework5
open Xunit


let args = [|
    [|"9"; "+"; "3"|]
    [|"9.6"; "/"; "3.2"|]
    [|"9.62341"; "-"; "3.21"|]
    [|"6.4646"; "*"; "9"|]
    [|"a"; "-"; "9"|]
    [|"6.4646"; "-"; "("|]
    [|"6.4646"; "^"; "3"|]
    [|"6.4646"; "^"; "3"; "5"; "%"|]
    [|"6"; "%"; "3"|]
|]

[<Theory>]
[<InlineData(0, 9, CalculatorOperation.Plus, 3)>]
[<InlineData(1, 9.6, CalculatorOperation.Divide, 3.2)>]
[<InlineData(2, 9.62341, CalculatorOperation.Minus, 3.21)>]
[<InlineData(3, 6.4646, CalculatorOperation.Multiply, 9)>]

let Parser_SuccessParse(i, val1, op, val2) =
    let result = Parser.ParseArguments args.[i]
    match result with
    | Ok y ->
        Assert.Equal(val1, y.Item1)
        Assert.Equal(op, y.Item2)
        Assert.Equal(val2, y.Item3)
    | Error n -> Assert.Equal(HundledExceptions.WrongArgFormat, n)
    
    
[<Theory>]
[<InlineData(7)>]
let Parser_WrongLength_WrongArgLengthExceptionReturned(i) =
    let result = Parser.ParseArguments args.[i]
    match result with
    | Ok y ->
        Assert.Equal(decimal 1, y.Item1)
        Assert.Equal(CalculatorOperation.Multiply, y.Item2)
        Assert.Equal(decimal 1, y.Item3)
    | Error n -> Assert.Equal(HundledExceptions.WrongArgLength, n)
   

[<Theory>]
[<InlineData(4)>]
[<InlineData(5)>]
let Parser_WrongArgFormat_WrongArgFormatReturned(i) =
    let result = Parser.ParseArguments args.[i]
    match result with
    | Ok y ->
        Assert.Equal(decimal 1, y.Item1)
        Assert.Equal(CalculatorOperation.Multiply, y.Item2)
        Assert.Equal(decimal 1, y.Item3)
    | Error n -> Assert.Equal(HundledExceptions.WrongArgFormat, n)


[<Theory>]
[<InlineData(6)>]
[<InlineData(8)>]

let Parser_WrongOperation_WrongOperationReturned(i) =
    let result = Parser.ParseArguments args.[i]
    match result with
    | Ok y ->
        Assert.Equal(decimal 1, y.Item1)
        Assert.Equal(CalculatorOperation.Multiply, y.Item2)
        Assert.Equal(decimal 1, y.Item3)
    | Error n -> Assert.Equal(HundledExceptions.WrongOperation, n)
