namespace SingleWebSharper

open WebSharper

module Remoting =

    [<Remote>]
    let Process input =
        async {
            return "You said: " + input
        }

    [<Remote>]
    let TuPuQuoi input =
        async {
            return "Tu pus le " + input
        }