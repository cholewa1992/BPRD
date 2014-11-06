module ListLength
let rec len xs = 
        match xs with
        | []    -> 0
        | x::xr -> 1 + len xr;;


let rec lenc xs k =
        match xs with
        | []    -> k 0
        | x::xr -> lenc xr (fun v -> k(v + 1));;

let rec leni xs a =
        match xs with
        | []    -> a
        | x::xr -> leni xr (a + 1);;
