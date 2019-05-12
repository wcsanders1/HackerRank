let getContainer() =
    stdin.ReadLine().Split(' ')
    |> Array.map (fun i -> i |> int64)

let getContainers() = 
    let numberOfBuckets = stdin.ReadLine() |> int
    let containers = Array2D.zeroCreate numberOfBuckets numberOfBuckets
    let rec f bucket = 
        if bucket >= numberOfBuckets
        then containers
        else 
            let container = getContainer()
            for i in 0..numberOfBuckets - 1 do
                containers.[bucket, i] <- container.[i]
            f (bucket + 1) 
    f 0

let getCases caseNum =
    let rec f case cases =
        if case >= caseNum
        then cases
        else f (case + 1) (getContainers() :: cases)
    f 0 []
    |> List.rev
    |> List.toArray

let ballsInEachContainer (container:int64[,]) =
    let numberOfBuckets = container.[0,*].Length
    let rec getTotals bucket (totalInBuckets, totalColors)  =
        if bucket >= numberOfBuckets
        then (totalInBuckets, totalColors)
        else
            let bucketTotal = container.[bucket,*]
            let colorTotal = container.[*,bucket]
            getTotals (bucket + 1) ((bucketTotal :: totalInBuckets), (colorTotal :: totalColors))
    getTotals 0 ([], [])

let compareLists = List.compareWith (fun elem1 elem2 ->
    if elem1 <> elem2 then 1
    else 0)

let getSolution (container:int64[]list * int64[]list) = 
    let (amount, balls) = container;
    let sortedAmount = amount |> List.map (fun a -> Array.sum a) |> List.sort;
    let sortedBalls = balls |> List.map (fun b -> Array.sum b) |> List.sort;
    match compareLists sortedAmount sortedBalls with
    | 1 -> stdout.WriteLine("Impossible")
    | 0 -> stdout.WriteLine("Possible")
    | _ -> failwith("Invalid comparison result")
            

[<EntryPoint>]
let main _ =
    let containers = getCases (stdin.ReadLine() |> int)
    for container in containers do
        getSolution (ballsInEachContainer container)
    0

