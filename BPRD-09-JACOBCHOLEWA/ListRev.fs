module ListRev
let rec rev xs = 
        match xs with 
        | [] -> []
        | x::xr -> rev xr @ [x];;

let rec revc xs k =
        match xs with
        | [] -> k []
        | x::xr -> revc xr (fun v -> k(v @ [x]));;

let rec revi xs a =
        match xs with
        | [] -> a
        | x::xr -> revi xr (x::a);;
