open System
open System.Linq

type Grid(rowCount, columnCount) =
    let privateGrid = Array2D.zeroCreate rowCount columnCount
    member val RowCount = rowCount with get
    member val ColumnCount = columnCount with get
    member this.Item
        with get(row, column) = privateGrid.[row, column]
        and set(row, column) value = privateGrid.[row, column] <- value

let getRowsAndColumns (rawRowsAndColumns:string) = 
    rawRowsAndColumns.Split(' ').Select(fun s -> s |> int).ToArray()

let getGrid rowCount columnCount =
    let grid = new Grid(rowCount, columnCount)
    for rowNumber in 0 .. rowCount - 1 do
        let newRow = Console.ReadLine().ToCharArray()
        for columnNumber in 0 .. columnCount - 1 do
            grid.[rowNumber, columnNumber] <- newRow.[columnNumber]
    grid

let patternExists (initialGridRow:int32) (initialGridColumn:int32) (grid:Grid) (pattern:Grid) =
    let mutable gridColumn = initialGridColumn
    let mutable gridRow = initialGridRow
    //let mutable patternRow = 0
    //let mutable patternColumn = 0
    let mutable exists = true
    //let mutable resolved = false
    for patternRow in 0 .. pattern.RowCount - 1 do
    //while patternRow < pattern.RowCount && exists do
        if gridRow >= grid.RowCount
        then exists <- false
        else 
            for patternColumn in 0 .. pattern.ColumnCount - 1 do
            //while patternColumn < pattern.ColumnCount && exists do
                if gridColumn >= grid.ColumnCount || grid.[gridRow, gridColumn] <> pattern.[patternRow, patternColumn]
                then exists <- false
                gridColumn <- gridColumn + 1
                //patternColumn <- patternColumn + 1
        gridRow <- gridRow + 1
        gridColumn <- initialGridColumn
        //patternRow <- patternRow + 1
        //resolved <- true
    exists

let getAnswer (grid:Grid) (pattern:Grid) =
    let mutable answer = "NO"
    for gridRow in 0 .. grid.RowCount - 1 do
        for gridColumn in 0 .. grid.ColumnCount - 1 do
            if patternExists gridRow gridColumn grid pattern
            then answer <- "YES"
    answer

[<EntryPoint>]
let main _ =
    let testCases = Console.ReadLine() |> int
    for _ in 0 .. testCases - 1 do
        let gridRowsAndColumns = Console.ReadLine() |> getRowsAndColumns
        let gridRowCount = gridRowsAndColumns.[0]
        let gridColumnCount = gridRowsAndColumns.[1]
        
        let grid = getGrid gridRowCount gridColumnCount

        let patternRowsAndColumns = Console.ReadLine() |> getRowsAndColumns
        let patternRowCount = patternRowsAndColumns.[0]
        let patternColumnCount = patternRowsAndColumns.[1]

        let pattern = getGrid patternRowCount patternColumnCount

        getAnswer grid pattern |> Console.WriteLine
    0
