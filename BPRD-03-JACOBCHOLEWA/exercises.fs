module exercises;;

//Exercise 4.1
let e1 = "1+2"
let e2 = "if 2 < 3 then 1 else 2"
let e3 = "let f x = x in f 5 end"

//Exercise 4.2
let e4 = "let sum x = if 0<x then x + sum (x-1) else 1  in sum 1000 end"
let e5 = "let threeIn n = if 0 < n then 3 * (threeIn (n-1)) else 1 in threeIn 8 end";; 
let e6 = "let threeIn n = if 0 < n then 3 * (threeIn (n-1)) else 1 in let sum x = if 0<x then threeIn x + sum(x-1) else threeIn x in sum 11 end end";;
let e7 = "let InEight x = let pow n = if 0 < n then x * (pow (n-1)) else 1 in pow 8 end in let sum x = if 0 < x then InEight x + sum(x-1) else InEight x in sum 10 end end";;

//Exercise 4.3
//Please see the modified version of Fun.fs and Absyn.fs in the Fun/ directory

//Exercise 4.4
//Please see the modified version of FunPar.fsy and FunLex.fsl in the Fun/ directory

//Exercise 4.5
//Please see the modified version of FunPar.fsy and FunLex.fsl in the Fun/ directory
