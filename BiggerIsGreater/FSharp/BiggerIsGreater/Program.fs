open System

let NoAnswer = "no answer"

let rec removeFirst predicate = function
    | [] -> []
    | h :: t when predicate h -> t
    | h :: t -> h :: removeFirst predicate t

let sortString (charArray:char[]) (index:int) =
    let replacementIndex = index - 1
    let replacedChar = charArray.[replacementIndex]
    let replacementList = charArray |> Seq.skip (replacementIndex + 1) |> Seq.sortBy(fun c -> c) |> Seq.toList
    let replacementChar = replacementList |> Seq.find(fun c -> c > replacedChar)
    let replacedArray = charArray |> Seq.toList |> List.mapi(fun i v -> if i = replacementIndex then replacementChar else v)
    let sortedReplacementList = replacedChar :: replacementList |> removeFirst(fun c -> c = replacementChar) |> List.sort
    let partialAnswer = replacedArray |> Seq.take (replacementIndex + 1) |> Seq.toList
    let answer = Seq.concat [partialAnswer; sortedReplacementList] |> Seq.toArray
    new String(answer)

let (|SortHere|_|) (charArray:char[]) (index:int) = 
    if charArray.[index - 1] < charArray.[index] 
    then Some() 
    else None

let getAnswer (problem:string) =
    let charArray = Seq.toArray problem
    let rec f index = 
        match index with
        | 0 -> NoAnswer
        | SortHere charArray -> sortString charArray index
        | _ -> f (index - 1)
    f (charArray.Length - 1)

let biggerIsBetter (problem:string) = 
    match problem.Length with
    | length when length <= 1 -> NoAnswer
    | _ -> getAnswer problem

[<EntryPoint>]
let main _ =
    let cases = Console.ReadLine() |> int
    for _ in 0 .. cases - 1 do
        let problem = Console.ReadLine()
        biggerIsBetter problem |> Console.WriteLine
    0 
