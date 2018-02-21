// Seq
let seqX x =
    [1..5] |> Seq.map ((*) x)

let sq =
    seq {
        printfn "fst eval"
        for i in [3..4] do
            yield 10*i
        yield! seqX 1
        yield 20
        printfn "snd eval"
        yield! seqX 2
    }

let sqArr = sq |> Seq.toArray


// Async
#r "System.Net.Http.dll"
open System.Net.Http

let fetchAsync =
    let httpClient = new HttpClient()
    fun (url:string) ->
        async {
            try
                let! html = httpClient.GetStringAsync(url)
                            |> Async.AwaitTask
                return Ok (url, html)
            with
            | ex -> 
                return Error ex.Message
        }

[ 
    "https://google.com"
    "https://tut.by"
    "https://dev.by"
]
|> Seq.map fetchAsync
|> Async.Parallel
|> Async.RunSynchronously
|> Seq.iter 
    (function
     | Ok (url, html) -> 
        printfn "[OK] Resp from '%s' starts from '%s'"
            url (html.Substring(0,100))
     | Error msg ->
        printfn "[Err] Msg: %s" msg
    )




(**
// http://mbrace.io/programming-model.html

let first = cloud { return 15 }
let second = cloud { return 27 }

cloud {
    let! x = first
    let! y = second
    return x + y
}
*)

// https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/computation-expressions

