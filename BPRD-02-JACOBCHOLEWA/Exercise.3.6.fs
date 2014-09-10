module compString

open Parse;;
open Expr;;


let compString s = scomp <<  fromString <| s <| []


