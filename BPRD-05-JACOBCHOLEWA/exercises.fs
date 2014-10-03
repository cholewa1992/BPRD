//Exercise 7.1
let e1 =
        Prog //Program decl
                [Fundec //Function decl
                        (null,"main",[(TypI, "n")], //parameter decl
                                Block //{} decl
                                        [Stmt //While statment decl
                                                (While
                                                        (Prim2 (">",Access (AccVar "n"),CstI 0), //while condition as expr
                                                                Block //While body decl
                                                                        [Stmt (Expr (Prim1 ("printi",Access (AccVar "n")))); //List of expresions inside the while body
                                                                                Stmt
                                                                                        (Expr
                                                                                                (Assign
                                                                                                        (AccVar "n",Prim2 ("-",Access (AccVar "n"),CstI 1))))])); //Here the acess type is being used to declare and access variables
                                                                                                                Stmt (Expr (Prim1 ("printc",CstI 10)))])]       


//Exercise 7.2
//Please see e72i.c, e72ii.c and e72iii.c

//Exercise 7.3
//Please see CLex.fsl, CPar.fsy, e73i.c, e73ii.c e73iii.c

//Exercise 7.4
//Please see Absyn.fs and Interp.fs

//Exercise 7.5
//Please see CPar.fsy, e74i.c, e74ii.c, e74iii.c
