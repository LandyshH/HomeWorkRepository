module Tests.ProgramTests

open Homework5
open Xunit

let args = [|
    [|"9"; "+"; "3"|]
    [|"9.6"; "/"; "3.2"|]
    [|"9.62341"; "-"; "3.21"|]
    [|"6.4646"; "-"; "9"|]
    [|"a"; "-"; "9"|]
    [|"6.4646"; "-"; "("|]
    [|"6.4646"; "^"; "3"|]
    [|"6.4646"; "^"; "3"; "5"; "%"|]
|]

[<Theory>]
[<InlineData(0)>]
[<InlineData(1)>]
[<InlineData(2)>]
[<InlineData(3)>]

let ProgramTest_AllArgumentsCorrect_0Returned (i) =
    let str = args.[i]
    let result = Program.Main str 
    Assert.Equal(0, result)
    
[<Theory>]
[<InlineData(4)>]
[<InlineData(5)>]

let ProgramTest_WrongArgFormatInt_3Returned (i) =
    let str = args.[i]
    let result = Program.Main(str)
    Assert.Equal(3, result)
        

[<Theory>]
[<InlineData(6)>]   
let ProgramTest_WrongOperation_1Returned (i) =
    let str = args.[i]
    let result = Program.Main str
    Assert.Equal(1, result)
    
[<Theory>]
[<InlineData(7)>]   
let ProgramTest_WrongArgLength_2Returned (i) =
    let str = args.[i]
    let result = Program.Main str
    Assert.Equal(2, result)

    
