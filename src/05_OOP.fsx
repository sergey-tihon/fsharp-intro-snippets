// Record type

type MyRecord =
    { x:int; y:int}

    override this.ToString() =
        sprintf "Point(%d,%d)" this.x this.y

let p = { x= 10; y = 20}
printfn "%O" p



// Types and OOP (inherit, member, override, ctor, ctor body)

type IAddingService =
    abstract member Add: int -> int -> int

type MyAddingService (z) =
    let Z = z*z // ctor body

    interface IAddingService with 
        member this.Add x y = 
            x + y + Z

let masT = MyAddingService (2)
let masI = masT :> IAddingService

//masT.Add 1 2    // error
masI.Add 1 2
