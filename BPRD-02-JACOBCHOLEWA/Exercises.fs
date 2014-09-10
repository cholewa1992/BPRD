Exercise 3.2
 (b|ab)+a?|a
Please see the image file NFADFA.JPG

Exercise 3.3
 Main
 => Expr EOF
 => LET z EQ Expr IN Expr END EOF
 => LET z EQ Expr IN Expr + Expr END EOF
 => LET z EQ Expr IN Expr + Expr * Expr END EOF
 => LET z EQ Expr IN Expr + Expr * 3 END EOF
 => LET z EQ Expr IN Expr + 2 * 3 END EOF
 => LET z EQ Expr IN z + 2 * 3 END EOF
 => LET z EQ 17 IN z + 2 * 3 END EOF

Exercise 3.4
Please see the image file TREE.JPG

Exercise 3.5
Cool, it worked!
1:  Prim("+",CstI 1, Prim ("*",CstI 2, CstI 3))
2:  Prim ("-",Prim ("-",CstI 1,CstI 2),CstI 3)
3:  Prim ("+",CstI 1,CstI -2)
4:  Error
5:  Error
6:  Error
7:  Let ("z",CstI 17,Prim ("+",Var "z",Prim ("*",CstI 2,CstI 3)))
8:  Error
9:  Error
10: Prim("+",CstI 1,Let("x",CstI 5,Prim("+",Let ("y",Prim ("+",CstI 7,Var "x"),Prim ("+",Var "y",Var "y")),Var "x")))

Exercise 3.6
let compString s = scomp << fromString <| s <| []

Exercise 3.7
Please see files in folder exercise.3.8/
