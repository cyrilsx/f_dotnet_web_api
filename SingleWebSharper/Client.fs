namespace SingleWebSharper

open WebSharper
open WebSharper.JavaScript
open WebSharper.Html.Client

[<JavaScript>]
module Client =


    let TuPuLeChat input result =
        async {
            let! data = Remoting.TuPuQuoi(input)
            return result input
        }
        |> Async.Start

    let Start input k =
         async {
            let! data = Remoting.Process(input)
            return k data
        }
        |> Async.Start

    let Main () =
        let input = Input [Attr.Value ""]
        let label = Div [Text ""]
        Div [
            input
            label
            Button [Text "Click"]
            |>! OnClick (fun _ _ ->
                Start input.Value (fun out ->
                    label.Text <- out))
        ]
        let inputChat = Input [Attr.Value "chat"]
        let labelAn = Div [Text "Animal"]
        Div [
            inputChat 
            labelAn
            Button [Text "Mouhaha"]
            |>! OnClick (fun _ _ ->
                TuPuLeChat inputChat.Value (fun out ->
                    labelAn.Text <- out))
        ]


        ]
