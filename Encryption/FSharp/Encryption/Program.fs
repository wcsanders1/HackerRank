open System

let removeSpaces (text:string) =
    text.Split(" ", StringSplitOptions.RemoveEmptyEntries) |> String.Concat

let encrypt (text:string) =
    let squareRoot = text.Length |> float |> Math.Sqrt
    let textLength = text.Length
    let rows = squareRoot |> Math.Floor |> int
    let columns = squareRoot |> Math.Ceiling |> int 
    let sb = new System.Text.StringBuilder()
    for row in 0 .. rows do
        for column in row .. columns .. textLength do
            if column < textLength && sb.Length < textLength + rows
            then sb.Append(text.[column]) |> ignore
        sb.Append(" ") |> ignore
    sb.ToString()

[<EntryPoint>]
let main argv =
    let unencrypted = Console.ReadLine()
    removeSpaces unencrypted |> encrypt |> Console.WriteLine
    0
