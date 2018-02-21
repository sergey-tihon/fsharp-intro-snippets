// Mailbox processor = Agent

let helloWorldAgent = 
    MailboxProcessor.Start(fun inbox-> 
        let rec loop() = 
            async{
                let! msg = inbox.Receive()
                printfn "Hello, %s !" msg
                return! loop()  
            }
        loop() 
    )

helloWorldAgent.Post "Sergey"
helloWorldAgent.Post "Everyone"



let helloWorldAgentWithMemory = 
    MailboxProcessor.Start(fun inbox-> 
        let rec loop mem = 
            async{
                let! msg = inbox.Receive()
                match Set.contains msg mem with
                | true -> 
                    printfn "We already met, %s." msg
                    return! loop mem
                | false ->
                    printfn "Hello, %s !" msg
                    return! loop (mem |> Set.add msg)
            }
        loop (Set.empty)
    )

helloWorldAgentWithMemory.Post "Sergey"
helloWorldAgentWithMemory.Post "Everyone"


(**
Popular actor .NET frameworks
- Proto.Actor
- Akka.NET
- Orleans
- Thespian
*)