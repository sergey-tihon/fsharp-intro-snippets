// Discriminated unions

type ConnectionType =
    | Connected
    | Disconnected
    | ErrorState

// Maybe DU

type Maybe<'a> =
    | Nothing
    | Just of a:'a

// Option <'a> = None | Some of a:'a
let x = None
let y = Some 10

let z = x |> Option.map (fun x -> x * 2)



// Result type

type MyResult<'a> = Result<'a, string>

let score : MyResult<int> =
    Error "+++" |> Result.map ((*) 2)

let printScore score =
    match score with
    | Ok (x) when x > 10 ->
        printfn "Your score is good!"
    | Ok (_) ->
        printfn "Your score is fine!"
    | Error (err) ->
        failwithf "Score calculation error '%s'" err




// Active patterns
let (|Integer|_|) (str: string) =
   printfn "Try parse int"
   match System.Int32.TryParse(str) with
   | true, x -> Some(x)
   | false, _ -> None

let (|Float|_|) (str: string) =   
   printfn "Try parse double"
   match System.Double.TryParse(str) with
   | true, x -> Some(x)
   | false, _ -> None

let parseNumeric str =
   match str with
   | Integer i -> printfn "%d : Integer" i
   | Float f -> printfn "%f : Floating point" f
   | _ -> printfn "%s : Not matched." str




let (|Odd|Even|) x =
    match x % 2 with
    | 1 -> Odd
    | _ -> Even

let checker x = 
    match x with
    | Odd -> printfn "'%d' is odd" x
    | Even -> printfn "'%d' is even" x