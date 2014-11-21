object Expr {

	sealed abstract class Expr
	case class CstI(value: Int) extends Expr
	case class Var(value: String) extends Expr
	case class Prim(op: String, e1: Expr, e2: Expr) extends Expr

	def eval(e: Expr, env: Map[String, Int]): Int = 
		e match {
			case CstI(i) => i
			case Prim(op, e1, e2) =>
				val v1 = eval(e1, env)
				val v2 = eval(e2, env)
					op match {
						case "+" 	=>	v1 + v2
						case "-" 	=>	v1 - v2
						case "*" 	=>	v1 * v2
						case "/" 	=>	v1 / v2
						case "<" 	=>	if (v1 < v2) 1 else 0
						case ">" 	=>	if (v1 > v2) 1 else 0
						case "&&" 	=>	if (v1 != 0 && v2 != 0) 1 else 0
					}

			case Var(x) => env get x
					env get x match {
    					case None    => throw new IllegalArgumentException(x + " is not in the map");
   						case Some(v) => v
  					}
			}

	def eval2(e: Expr, env: Map[String, Int]): Option[Int] = 
		e match {
			case CstI(i) => Some(i)
			case Prim(op, e1, e2) =>
				val v1 = eval2(e1, env)
				val v2 = eval2(e2, env)
				(v1,v2) match{
					case (Some(v1), Some(v2)) =>
					op match {
						case "+" 	=>	Some(v1 + v2)
						case "-" 	=>	Some(v1 - v2)
						case "*" 	=>	Some(v1 * v2)
						case "/" 	=>	if(v2 != 0) Some(v1 / v2) else None
						case "<" 	=>	if (v1 < v2) Some(1) else Some(0)
						case ">" 	=>	if (v1 > v2) Some(1) else Some(0)
						case "&&" 	=>	if (v1 != 0 && v2 != 0) Some(1) else Some(0)
					}
					case _ => None
				}

			case Var(x) => env get x
			}

	def eval3(e: Expr, env: Map[String, Int]): Option[Int] = 
		e match {
			case CstI(i) => Some(i)
			case Prim(op, e1, e2) =>

				val v1 = eval2(e1, env)
				val v2 = eval2(e2, env)

				for(
					i1 <- v1; 
					i2 <- v2; 
					value <- op match {
						case "+" 	=>	Some(i1 + i2)
						case "-" 	=>	Some(i1 - i2)
						case "*" 	=>	Some(i1 * i2)
						case "/" 	=>	if(i2 != 0) Some(i1 / i2) else None
						case "<" 	=>	if (i1 < i2) Some(1) else Some(0)
						case ">" 	=>	if (i1 > i2) Some(1) else Some(0)
						case "&&" 	=>	if (i1 != 0 && i2 != 0) Some(1) else Some(0)
					})
				yield value;
			case Var(x) => env get x
			}


	def simplify(e: Expr) : Expr =
		e match{
			case Prim("+", CstI(0), Var(x))	=>	Var(x)
			case Prim("+", Var(x), CstI(0))	=>	Var(x)
			case Prim("-", Var(x), CstI(0))	=>	Var(x)
			case Prim("-", Var(x1), Var(x2)) if (x1 == x2) => CstI(0)
			case Prim("*", CstI(1), Var(x))	=>	Var(x)
			case Prim("*", Var(x), CstI(1))	=>	Var(x)
			case Prim("*", CstI(0), Var(x))	=>	CstI(0)
			case Prim("*", Var(x), CstI(0))	=>	CstI(0)
			case _ => e
		}

	def main(args: Array[String]) {

		//Eval testing ( I skipped the underlying eval iterations as they stack nice opon eachother)
		val ex01 = Prim("+", CstI(7), Prim("*", CstI(9), CstI(10)))
		val ex02 = Prim("*", CstI(7), Prim("-", CstI(10), Prim("+", CstI(6), CstI(5))))
		val ex03 = Prim("*", CstI(7), Prim("<", CstI(10), Prim("+", CstI(6), CstI(5))))
		val ex04 = Prim("*", Var("x"), Var("y"))		
		val ex05 = Prim("*", Var("x"), CstI(0))

		println("eval ex01 = " + eval(ex01, Map()))
		println("eval ex02 = " + eval(ex02, Map()))
		println("eval ex03 = " + eval(ex03, Map()))
		println("eval ex04 = " + eval(ex04, Map("x" -> 5, "y" -> 6)))
		println("eval ex05 = " + eval(simplify(ex05), Map("x" -> 5, "y" -> 6)))

		//Eval 2 testing
		val ex06 = Prim("+", CstI(7), Prim("*", CstI(9), CstI(10)))
		val ex07 = Prim("*", CstI(7), Prim("-", CstI(10), Prim("+", CstI(6), CstI(5))))
		val ex08 = Prim("*", CstI(7), Prim("<", CstI(10), Prim("+", CstI(6), CstI(5))))
		val ex09 = Prim("*", Var("x"), Var("y"))		
		val ex10 = Prim("*", Var("x"), CstI(0))
		val ex11 = Prim("/", Var("x"), CstI(0))

		println("eval ex06 = " + eval2(ex06, Map()))
		println("eval ex07 = " + eval2(ex07, Map()))
		println("eval ex08 = " + eval2(ex08, Map()))
		println("eval ex09 = " + eval2(ex09, Map("x" -> 5, "y" -> 6)))
		println("eval ex10 = " + eval2(simplify(ex10), Map("x" -> 5, "y" -> 6)))
		println("eval ex11 = " + eval2(simplify(ex11), Map("x" -> 5, "y" -> 6)))

		//Eval 3 testing
		val ex12 = Prim("+", CstI(7), Prim("*", CstI(9), CstI(10)))
		val ex13 = Prim("*", CstI(7), Prim("-", CstI(10), Prim("+", CstI(6), CstI(5))))
		val ex14 = Prim("*", CstI(7), Prim("<", CstI(10), Prim("+", CstI(6), CstI(5))))
		val ex15 = Prim("*", Var("x"), Var("y"))		
		val ex16 = Prim("*", Var("x"), CstI(0))
		val ex17 = Prim("/", Var("x"), CstI(0))

		println("eval ex12 = " + eval3(ex12, Map()))
		println("eval ex13 = " + eval3(ex13, Map()))
		println("eval ex14 = " + eval3(ex14, Map()))
		println("eval ex15 = " + eval3(ex15, Map("x" -> 5, "y" -> 6)))
		println("eval ex16 = " + eval3(simplify(ex16), Map("x" -> 5, "y" -> 6)))
		println("eval ex17 = " + eval3(simplify(ex17), Map("x" -> 5, "y" -> 6)))

	}
}

