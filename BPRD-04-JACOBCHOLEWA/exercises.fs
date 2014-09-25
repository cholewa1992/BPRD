module exercises
open ParseAndRunHigher;;
open Absyn;;
//Exercise 6.1
let e1 = fromString "let add x = let f y = x+y in f end in add 2 5 end";;
let e2 = fromString "let add x = let f y = x+y in f end in let addtwo = add 2 in addtwo 5 end end";;
let e3 = fromString "let add x = let f y = x+y in f end in let addtwo = add 2 in let x = 77 in addtwo 5 end end end";; 
let e4 = fromString "let add x = let f y = x+y in f end in add 2 end";;

let r1 = run e1;; //r1 = 7
let r2 = run e2;; //r2 = 7
let r3 = run e3;; //r3 = 7
let r4 = run e4;; // r4 = Closure

//The result of r3 was expected as we are using static and not dynamic scope
//The results of r4 is an Closure of the function f x y with x already bound to 2. eg. calling eval (Call(Var "f",CstI 5)) [("f",r4)] would result 7

//Exercise 6.2
//The syntax have been changes according to the assignment and it is now possible to run following
let e5 = run <| fromString "fun x -> x*2";;
let r5 = eval (Call(Var "f", CstI 5)) [("f",e5)];; //equals 10
let e6 = fromString "let f = fun x -> x*2 in f 5 end";;
let r6 = run e6;; //equals 10

//Exercise 6.3
//I already did this in exercise 6.2

//Exercise 6.4.i
//The tree can be seen in the file trees.pdf
//The type of f should not be polymorphic because it will always return int 

//Exercise 6.4.ii
//The tree can be seen in the file trees.pdf
//As shown, the type of f can not be polymorphic

//Exercise 6.5.1
let e7 = fromString "let f x = 1 in f f end";; //int
let e8 = fromString "let f g = g g in f end";; //error as g can not be polymorphic in its own body 
let e9 = fromString "let f x = let g y = y in g false end in f 42 end";; //bool
let e10 = fromString "let f x = let g y = if true then y else x in g false end in f 42 end";; //Ill typed as the if returns both bool and int
let e11 = fromString "let f x = let g y = if true then y else x in g false end in f true end";; //bool

//Exercise 6.5.2
let e12 = fromString "let f x = if x then true else false in f end";;
let e13 = fromString "let f x = x * x in f end";;
let e14 = fromString "let f x = let g y = x*y in g end in f end";;
let e15 = fromString "let f x = let g y = x in g end in f end";;
let e16 = fromString "let f x = let g y = y in g end in f end";;
//I cant figure out how to do (a -> b) -> (b -> c) -> (a -> c)
let e18 = fromString "let f x = f x in f end";;
let e19 = fromString "let f x = f x in f 8 end";;
