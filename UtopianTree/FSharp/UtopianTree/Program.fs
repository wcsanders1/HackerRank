// Learn more about F# at http://fsharp.org

open System

let square x = x * x

[<EntryPoint>]
let main argv =
    let strNumber = Console.ReadLine();
    let (_, number) = Int32.TryParse strNumber

    Console.WriteLine(square number)
    Console.ReadKey();
    0 // return an integer exit code
