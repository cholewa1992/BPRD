(* File Expr/Absyn.fs
   Abstract syntax for the simple expression language 
 *)

module Absyn

type expr = 
  | CstI of int
  | If of expr * expr * expr
  | Var of string
  | Let of string * expr * expr
  | Prim of string * expr * expr
