open System
open Suave
open Suave.Http
open Suave.Http.Applicatives
open Suave.Http.Successful
open Suave.Web
open Newtonsoft.Json

type Movie = {
    Name : string
    Year: int
}

let movies = Map.empty
                    .Add(1, { Name = "Bad Xavier"; Year = 1995 })
                    .Add(2, { Name = "Bad Xavier 2"; Year = 2003 })



let app =
  choose
    [ GET >>= choose
        [ pathScan "/movie/%d" (fun(a) -> OK(JsonConvert.SerializeObject(movies.TryFind(a))))
          url "/movies" >>= OK(JsonConvert.SerializeObject(movies))]
      POST >>= choose
        [ url "/hello" >>= OK "Hello POST"
          url "/goodbye" >>= OK "Good bye POST" ] ]

// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
//[<EntryPoint>]
//let main argv = 
   // printfn "%A" argv
 //0 // return an integer exit 
startWebServer defaultConfig app
  
