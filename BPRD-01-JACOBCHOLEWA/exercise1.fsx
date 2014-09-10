// Exercise 1.1.i
let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr;;

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim("==", e1, e2) -> if (eval e1 env) = (eval e2 env) then 1 else 0
    | Prim("max", e1, e2) -> if (eval e1 env) > (eval e2 env) then (eval e1 env) else (eval e2 env)
    | Prim("min", e1, e2) -> if (eval e1 env) < (eval e2 env) then (eval e1 env) else (eval e2 env)
    | Prim _            -> failwith "unknown primitive";;

// Exercise 1.1.ii
printfn "%d" (eval (Prim("max", CstI 3, CstI 6)) []);; //Result = 6
printfn "%d" (eval (Prim("max", CstI 6, CstI 3)) []);; //Result = 6
printfn "%d" (eval (Prim("min", CstI 3, CstI 6)) []);; //Result = 3
printfn "%d" (eval (Prim("min", CstI 6, CstI 3)) []);; //Result = 3
printfn "%d" (eval (Prim("==", CstI 5, CstI 3)) []);; //Result = 0
printfn "%d" (eval (Prim("==", CstI 6, CstI 6)) []);; //Result = 1

//Exercise 1.1.iii
let rec eval2 e (env : (string * int) list) : int =
    match e with
    |   CstI i -> i
    |   Var x -> lookup env x 
    |   Prim(ope, e1, e2) ->
        let i1 = eval2 e1 env
        let i2 = eval2 e2 env
        match ope with
        |   "+" -> i1 + i2
        |   "*" -> i1 * i2
        |   "-" -> i1 - i2
        |   "==" -> if i1 = i2 then 1 else 0
        |   "max" -> if i1 > i2 then i1 else i2
        |   "min" -> if i1 < i2 then i1 else i2
        |   _ -> failwith "unknown operator"


printfn "%d" (eval2 (Prim("max", CstI 3, CstI 6)) []);; //Result = 6
printfn "%d" (eval2 (Prim("max", CstI 6, CstI 3)) []);; //Result = 6
printfn "%d" (eval2 (Prim("min", CstI 3, CstI 6)) []);; //Result = 3
printfn "%d" (eval2 (Prim("min", CstI 6, CstI 3)) []);; //Result = 3
printfn "%d" (eval2 (Prim("==", CstI 5, CstI 3)) []);; //Result = 0
printfn "%d" (eval2 (Prim("==", CstI 6, CstI 6)) []);; //Result = 1

//Exercise 1.1.iv
type expr2 = 
  | CstI of int
  | Var of string
  | Prim of string * expr2 * expr2
  | If of expr2 * expr2 * expr2;;

//Exercise 1.1.v

let rec eval3 (e : expr2) (env : (string * int) list) : int =
    match e with
    |   CstI i -> i
    |   Var x -> lookup env x 
    |   Prim(ope, e1, e2) ->
        let i1 = eval3 e1 env
        let i2 = eval3 e2 env
        match ope with
        |   "+" -> i1 + i2
        |   "*" -> i1 * i2
        |   "-" -> i1 - i2
        |   "==" -> if i1 = i2 then 1 else 0
        |   "max" -> if i1 > i2 then i1 else i2
        |   "min" -> if i1 < i2 then i1 else i2
        |   _ -> failwith "unknown operator"

    |   If(e1, e2, e3) -> if eval3 e1 env = 1 then eval3 e2 env else eval3 e3 env

printfn "%d" (eval3 (If(Prim("==", CstI 6, CstI 6), CstI 4, CstI 5)) []);; //Result = 4
printfn "%d" (eval3 (If(Prim("==", CstI 1, CstI 6), CstI 4, CstI 5)) []);; //Result = 5
printfn "%d" (eval3 (If(Var "a", CstI 11, CstI 22)) [("a",1)]);; //Result = 11

//Exercise 1.2.i
type aexpr = 
    |   CstI of int
    |   Var of string
    |   Add of aexpr * aexpr
    |   Mul of aexpr * aexpr
    |   Sub of aexpr * aexpr


//Exercise 1.2.ii
let e1 = Sub(Var "v",Add(Var "w", Var "z"))
let e2 = Mul(CstI 2, Sub(Var "v", Add(Var "w", Var "z")))

//Exercise 1.2.iii
let fmt aexpr =
    let rec fmtr aexpr s =
        match aexpr with
        | CstI i -> i.ToString()
        | Var s -> s
        | Add(e1,e2) -> "(" + fmtr e1 s + " + " + fmtr e2 s + ")" 
        | Mul(e1,e2) -> "(" + fmtr e1 s + " * " + fmtr e2 s + ")"
        | Sub(e1,e2) -> "(" + fmtr e1 s + " - " + fmtr e2 s + ")"
    fmtr aexpr "";;

printfn "%s" (fmt e1);;
printfn "%s" (fmt e2);;

//Exercise 1.2.iv
let rec simplify aexpr : aexpr = 
    match aexpr with
    | Add(e1,e2) -> 
        let e1 = simplify e1
        let e2 = simplify e2
        match (e1,e2) with
        | (CstI 0, e) -> e
        | (e, CstI 0) -> e
        | _ -> Add(e1,e2)

    | Sub(e1, e2) ->
        let e1 = simplify e1
        let e2 = simplify e2
        match (e1,e2) with
        | (e,CstI 0) -> e
        | (e1,e2) when e1 = e2 -> CstI 0
        | _ -> Sub(e1,e2)
    | Mul(e1,e2) ->
        let e1 = simplify e1
        let e2 = simplify e2
        match (e1,e2) with
        | (CstI 1,e) -> e
        | (e, CstI 1) -> e
        | (CstI 0, e) -> CstI 0
        | (e, CstI 0) -> CstI 0
        | _ -> Mul(e1,e2)
    | _ -> aexpr


printfn "%s" << fmt << simplify <| Mul(Sub(Mul(CstI 1, CstI 6),Mul(CstI 1, CstI 6)) ,CstI 2)

//Exercise 1.4
//Please look at the file MathSyntax.cs
