let getContainer() =
    stdin.ReadLine().Split(' ')
    |> Array.map (fun i -> i |> int)

let getContainers() = 
    let numberOfBuckets = stdin.ReadLine() |> int
    let containers:int[,] = Array2D.zeroCreate numberOfBuckets numberOfBuckets
    let rec f bucket = 
        if bucket > numberOfBuckets
        then containers
        else 
            let container = getContainer()
            for i in 0..numberOfBuckets - 1 do
                Array2D.set containers bucket i container.[i]
            f (bucket + 1) 
    f 0

let getCases caseNum =
    let rec f case cases =
        if case > caseNum
        then cases
        else f (case + 1) (getContainers() :: cases)
    f 0 []

[<EntryPoint>]
let main argv =
    let cases = getCases (stdin.ReadLine() |> int)
    0

