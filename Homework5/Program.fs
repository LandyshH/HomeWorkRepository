module Homework5.Program
 
[<EntryPoint>]
let Main(args: string[]) =
    let problem  = Parser.ParseArguments(args)
    match problem with
    | Ok res -> let result = Calculator.Calculate res
                printfn($"Result: {result}")
                0
    | Error ex ->
        match ex with
        | HundledExceptions.WrongOperation -> printfn("Wrong operation.")
                                              int ex
        | HundledExceptions.WrongArgLength -> printfn("Wrong arguments count.")
                                              int ex
        | HundledExceptions.WrongArgFormat -> printfn("Wrong argument format.")
                                              int ex
        