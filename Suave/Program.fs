open Suave
open Suave.Http
open Suave.Http.Applicatives
open Suave.Http.Successful
open Suave.Web

let app =
  choose
    [ GET >>= choose
        [ url "/hello" >>= OK "Hello GET"
          url "/goodbye" >>= OK "Good bye GET" ]
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
  
