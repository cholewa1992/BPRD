//Exercise 2.1
type expr = 
  | CstI of int
  | Var of string
  | Let of (string * expr) list * expr
  | Prim of string * expr * expr;;

  let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i -> i
    | Var x -> lookup env x 
    | Let(list, ebody) ->
        match list with
        | [] -> eval ebody env
        | (x,expr)::xs ->
        let xval = eval expr env 
        eval <| Let(xs, ebody) <| (x,xval) :: env
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim _            -> failwith "unknown primitive";;


let e1 = Let([("x", Prim("+", CstI 2, CstI 4)); ("y", Prim("-", Var "x", CstI 2))], Var "y")
printfn "%d" (eval e1 [])

//Exercise 2.2
let rec mem x vs = 
    match vs with
    | []      -> false
    | v :: vr -> x=v || mem x vr;;

let rec union (xs, ys) = 
    match xs with 
    | []    -> ys
    | x::xr -> if mem x ys then union(xr, ys)
               else x :: union(xr, ys);;

let rec minus (xs, ys) = 
    match xs with 
    | []    -> []
    | x::xr -> if mem x ys then minus(xr, ys)
               else x :: minus (xr, ys);;

let rec freevars e : string list =
    match e with
    | CstI i -> []
    | Var x  -> [x]
    | Let(list,ebody) -> 
        match list with
            | [] -> freevars ebody
            | (x,erhs)::xs -> union (freevars erhs, minus (freevars (Let(xs,ebody)), [x]))
    | Prim(ope, e1, e2) -> union (freevars e1, freevars e2);;

let e2 = Let([("x", Prim("+",Var "x", CstI 7))], Prim("+", Var "x", CstI 8))

printfn "%A" (freevars e1)
printfn "%A" (freevars e2)

//Exercise 2.3
type texpr =                            (* target expressions *)
  | TCstI of int
  | TVar of int                         (* index into runtime environment *)
  | TLet of texpr * texpr               (* erhs and ebody                 *)
  | TPrim of string * texpr * texpr;;

let rec getindex vs x = 
    match vs with 
    | []    -> failwith "Variable not found"
    | y::yr -> if x=y then 0 else 1 + getindex yr x;;

let rec tcomp (e : expr) (cenv : string list) : texpr =
    match e with
    | CstI i -> TCstI i
    | Var x  -> TVar (getindex cenv x)

    | Let(list,ebody) ->
        match list with
        | [] -> tcomp ebody cenv
        | (x,erhs)::xs -> TLet(tcomp erhs cenv, tcomp (Let(xs,ebody)) (x::cenv)) 
    | Prim(ope, e1, e2) -> TPrim(ope, tcomp e1 cenv, tcomp e2 cenv);;

printfn "%A" (tcomp e1 [])
