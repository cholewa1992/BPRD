object Expr2{
    sealed abstract class TypedExpr[T]
    //case class CstI(n: Int) extends TypedExpr[Int]
    //case class CstB(n: Boolean) extends TypedExpr[Boolean]
    case class Const[T](n: T) extends TypedExpr[T]
    case class Plus(e1: TypedExpr[Int], e2: TypedExpr[Int]) extends TypedExpr[Int]
    case class Times(e1: TypedExpr[Int], e2: TypedExpr[Int]) extends TypedExpr[Int]
    case class LessThanEq(e1: TypedExpr[Int], e2: TypedExpr[Int]) extends TypedExpr[Boolean]
    case class IfThenElse[T](cond: TypedExpr[Boolean], e1: TypedExpr[T], e2: TypedExpr[T]) extends TypedExpr[T]
    case class SeqAnd(e1: TypedExpr[Boolean], e2: TypedExpr[Boolean]) extends TypedExpr[Boolean]
    case class SeqOr(e1: TypedExpr[Boolean], e2: TypedExpr[Boolean]) extends TypedExpr[Boolean]

    def eval[T](e: TypedExpr[T]): T = e match {
        //case CstI(n) => n
        //case CstB(b) => b
        case Const(x) => x
        case Plus(e1, e2) => eval(e1) + eval(e2)
        case Times(e1, e2) => eval(e1) * eval(e2)
        case LessThanEq(e1, e2) => eval(e1) <= eval(e2)
        case IfThenElse(cond, e1, e2) => if (eval(cond)) eval(e1) else eval(e2)
        case SeqAnd(e1, e2) => if(eval(e1) && eval(e2)) true else false
        case SeqOr(e1, e2)  => if(eval(e1) || eval(e2)) true else false
    }

    def main(args: Array[String]) {

        /* OUT COMMENTED AS PART OF 11.5.iii

        //Eval testing ( I skipped the underlying eval iterations as they stack nice opon eachother)
        val ex01 = Plus(CstI(2),Times(CstI(13),CstI(4)))
        val ex02 = IfThenElse(LessThanEq(CstI(23),CstI(17)),CstI(7),Plus(CstI(3),CstI(21)))
        //val ex03 = IfThenElse(CstI(0),CstI(1),CstI(2))
        //val ex04 = IfThenElse(LessThanEq(CstI(12),CstI(3)),CstI(42),LessThanEq(CstI(3),CstI(7)))
        val ex05 = IfThenElse(LessThanEq(CstI(12),CstI(3)),LessThanEq(CstI(42),CstI(1000)),LessThanEq(CstI(3),CstI(7)))
        var ex06 = SeqAnd(CstB(true),CstB(false))
        var ex07 = SeqOr(CstB(true),CstB(false))
        
        println("eval ex01 = " + eval(ex01))
        println("eval ex02 = " + eval(ex02))
        //println("eval ex03 = " + eval(ex03))
        //println("eval ex04 = " + eval(ex04))
        println("eval ex05 = " + eval(ex05))
        println("eval ex06 = " + eval(ex06))
        println("eval ex07 = " + eval(ex07))

        */

        val ex01 = Plus(Const(2),Times(Const(13),Const(4)))
        println("eval ex01 = " + eval(ex01))

    }

}