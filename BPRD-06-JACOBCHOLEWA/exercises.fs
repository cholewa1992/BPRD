//Excercise 8.1
//Please see examples/ex3.formatted, examples/ex5.formatted and examples/ex3.trace

//Exercise 8.2
//Through this assigment i learned that i can't declare an int * but should declare an int and & to it, otherwise it won't run. The programs and their out and trace is located in e72/

//Exercise 8.3
//Please see Comp.fs

//Exercise 8.4
//There are much more instructions accessing variables which is not done in the handwritten one. (Accessing memory takes time)

//From the code i can deduct that the while loop is implemented by jumping to the end, then checking conditions nad then jump up again or fall though

GOTO 2
Label 1
[Statement]
Label 2
[calculate condition]
IFNZRO 1

// The if(e){stmt} is implemented by

[e1]
IFZERO 1
[stmt]
GOTO 2
Label 1
[eventual else bloc]
Label 2

// e1 && e2 is implemented by first calculating e1 and if not zero jumping to e2

[e1]
IFZERO 1
[e2]
IFZERO 1
CSTI 1
GOTO 2
Label 1
CSTI 0
Label 2

// e1 || e2 is implemented by

[e1]
IFNZRO 1
[e2]
IFNZRO 1
CSTI 0
GOTO label 2
Label 1
CSTI 1
Label 2

//And all three togetther this can joing to while(e1 && (e2 || e3))

//Exercise 8.5
//Please see CLex.fs, CPar.fs, Absyn.fs, Comp.fs and the example in e85/

//Exercise 8.6
//Please see Clex.fs, Cpar.fs, Absyn.fs, Comp.fs and the example in e86/
