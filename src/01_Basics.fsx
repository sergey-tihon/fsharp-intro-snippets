// Variable (immutable) and function
let x = 1
let y = 2.0

let f x = x + 1
let g x y = x + y

let q () = printfn "Hello"
let q' = fun () -> printfn "Hello"


let myPrint = printfn "%s"

let ``my variable`` = 56


let tuple = 2,"4"
let (_,s) = tuple
let s' = snd tuple


// Mutable variables
let mutable acc = 10
acc <- acc + 1


// custom operator
let (+|+) a b = (a+b)/2
let avg = 4 +|+ 10


// Pipe operator
let add x y = x + y
let r1 = add 2 3
// let (|>) x f = f x
let r2 = 3 |> add 2


// whitespaces & compilation
let result =
    [1..100]
    |> List.filter (fun x -> x%2 = 1)
    |> List.map (fun x -> x*x)



// recursion + tail recorsion 
let rec fact x = 
    if x <= 1 then 1
    else x * fact (x-1)

let fact' x =
    let rec factImpl x acc =
        if x <= 1 then acc
        else factImpl (x-1) (acc*x)
    factImpl x 1


// recursion + tail recorsion with continuations 
let rec fib x =
    if x <= 1 then 1
    else fib(x-1) + fib(x-2)

let fib' x =
    let rec fibImpl x cont =
        if x <= 1 then cont(1)
        else fibImpl (x-1) (fun res1 ->
                fibImpl (x-2) (fun res2 ->
                    cont(res1+res2)
                )
             )
    fibImpl (x) id



// units of measure

[<Measure>] type m // Distance, meters.
[<Measure>] type s // Time, seconds.

let x1 = 1.2<m>
let t1 = 1.0<s>
let v1 = 3.1<m/s>
let v2 = 2.7<m/s>

let x2 = v1 * t1
let x3 = x1 + x2


let genericSumUnits ( x : float<m>) (y: float<m>) = x + y
let result1 = genericSumUnits x1 x2
