open System

type ProfessorClass = {
    students:int32; 
    threshold:int32;
    arrivalTimes:int32[]
}

let getProfessorClass() = 
    let studentsThreshold = stdin.ReadLine().Split(' ') |> Array.map (fun i -> i |> int)
    let arrivalTimes = stdin.ReadLine().Split(' ') |> Array.map (fun i -> i |> int)
    {
        students = studentsThreshold.[0]; 
        threshold = studentsThreshold.[1]; 
        arrivalTimes = arrivalTimes
    }

let getProfessorClasses cases =
    let rec f case classes = 
        if case = 0 then classes else f (case - 1) (getProfessorClass() :: classes)
    f cases []

let lateStudents arrivalTimes = 
    arrivalTimes |> Array.filter (fun i -> i > 0) |> Array.length

let classCanceled professorClass = 
    let lateStudents = lateStudents professorClass.arrivalTimes
    if professorClass.students - lateStudents < professorClass.threshold then printf "YES\n" else printf "NO\n"

[<EntryPoint>]
let main _ =
    let cases = Console.ReadLine() |> int
    let classes = getProfessorClasses cases |> List.rev
    classes |> List.map (fun c -> classCanceled c) |> ignore
    0