module ListProd
let rec prod xs =
        match xs with
        | [] -> 1
        | x::xr -> x * prod xr;;

let rec prodc xs k =
        match xs with 
        | [] -> k 1
        | 0::xr -> 0
        | x::xr -> prodc xr (fun v -> k(v * x));;

let rec prodi xs a =
        match xs with
        | [] -> a
        | 0::xr -> 0
        | x::xr -> prodi xr (x*a);;
