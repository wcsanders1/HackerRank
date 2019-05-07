let getContainer() =
    stdin.ReadLine().Split(' ')
    |> Array.map (fun i -> i |> int)

let getContainers() = 
    let numberOfBuckets = stdin.ReadLine() |> int
    let containers = Array2D.zeroCreate numberOfBuckets numberOfBuckets
    let rec f bucket = 
        if bucket >= numberOfBuckets
        then containers
        else 
            let container = getContainer()
            for i in 0..numberOfBuckets - 1 do
                Array2D.set containers bucket i container.[i]
            f (bucket + 1) 
    f 0

let getCases caseNum =
    let rec f case cases =
        if case >= caseNum
        then cases
        else f (case + 1) (getContainers() :: cases)
    f 0 [] |> List.rev

let ballsInEachContainer (container:int[,]) =
    let numberOfBuckets = container.[0,*].Length
    let rec getTotals bucket (totalInBuckets, totalColors)  =
        if bucket >= numberOfBuckets
        then (totalInBuckets, totalColors)
        else
            let bucketTotal = container.[bucket,*]
            let colorTotal = container.[*,bucket]
            getTotals (bucket + 1) ((bucketTotal :: totalInBuckets), (colorTotal :: totalColors))
    getTotals 0 ([], [])

[<EntryPoint>]
let main argv =
    let containers = getCases (stdin.ReadLine() |> int)
    //let totals = ballsInEachContainer (containers |> List.toArray)
    stdout.WriteLine("Done")
    0

