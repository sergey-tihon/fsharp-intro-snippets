
// Type Providers

#I __SOURCE_DIRECTORY__
#I "../packages/FSharp.Data/lib/net45/"
#r "FSharp.Data.dll"
open FSharp.Data

// JSON Type Provider 

type Simple = JsonProvider<""" { "name":"Alex", "age":42 } """>

let simple = Simple.Parse(""" { "name":"Sergey", "age":20 } """)
simple.Age
simple.Name


// World Bank Type Provider

let data = WorldBankData.GetDataContext()

data
  .Countries.Belarus
  .Indicators.``High-technology exports (% of manufactured exports)``
|> Seq.iter (fun (year,value) -> printfn "Year %d : %f %%" year value )