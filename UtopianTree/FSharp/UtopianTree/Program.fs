open System

let (|Spring|Summer|) i =
    if i % 2 = 0 then Summer else Spring

let (|>|-=-|<|) cycles =
    let rec grow cycle height = 
        match cycle with
        | 0 -> height
        | Summer -> (grow (cycle - 1) (height)) + 1
        | Spring -> (grow (cycle - 1) (height)) * 2
    grow cycles 1

let getCycles cycleNum =
    let rec calc num cases = 
        if num = 0 then cases else calc (num - 1) (int(Console.ReadLine()) :: cases)
    calc cycleNum []

[<EntryPoint>]
let main _ =
    let cycleNums = List.rev (getCycles (int(Console.ReadLine())))
    for cycleNum in cycleNums do
        let solution = (|>|-=-|<|) cycleNum
        printf "%d\n" solution
    
    Console.ReadKey() |> ignore;
    0
