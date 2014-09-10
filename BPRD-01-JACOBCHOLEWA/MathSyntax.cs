class MathSyntax
{
    static void Main(string[] args)
    {

        var env = new System.Collections.Generic.Dictionary<string, int>();
        env.Add("z",5);
        env.Add("x",2);

        Expr e1 = new Add(new CstI(17), new Var("z")).Simplify();
        Expr e2 = new Mul(new Var("x"), new Var("z")).Simplify();
        Expr e3 = new Sub(new Mul(new CstI(17), new CstI(5)), new Var("z")).Simplify();
        Expr e4 = new Add(new CstI(17), new CstI(0)).Simplify();

        System.Console.Out.WriteLine(e1.ToString() + " = " + e1.Eval(env));
        System.Console.Out.WriteLine(e2.ToString() + " = " + e2.Eval(env));
        System.Console.Out.WriteLine(e3.ToString() + " = " + e3.Eval(env));
        System.Console.Out.WriteLine(e4.ToString() + " = " + e4.Eval(env));
        System.Console.ReadLine();
    }

    interface Expr
    {
        string ToString();
        int Eval(System.Collections.Generic.Dictionary<string, int> env);
        Expr Simplify();
    }

    class CstI : Expr
    {
        public int Value;
        public CstI(int i)
        {
            Value = i;
        }

        public new string ToString()
        {
            return Value.ToString();
        }

        public int Eval(System.Collections.Generic.Dictionary<string, int> env)
        {
            return Value;
        }

        public Expr Simplify()
        {
            return this;
        }
    }

    class Var : Expr
    {
        public string Value;
        public Var(string i)
        {
            Value = i;
        }

        public new string ToString()
        {
            return Value.ToString();
        }

        public int Eval(System.Collections.Generic.Dictionary<string, int> env)
        {
            return env[Value];
        }

        public Expr Simplify()
        {
            return this;
        }
    }

    abstract class Binop : Expr{
        public Expr E1;
        public Expr E2;
        public string Symb;

        public Binop(Expr e1, Expr e2){
            E1 = e1;
            E2 = e2;
        }

        public abstract int Eval(System.Collections.Generic.Dictionary<string, int> env);

        public new string ToString(){
            return "(" + E1.ToString() + Symb + E2.ToString() + ")";
        }

        public abstract Expr Simplify();
    }

    class Add : Binop
    {
        public Add(Expr e1, Expr e2) : base(e1, e2) { Symb = "+"; }
        public override int Eval(System.Collections.Generic.Dictionary<string, int> env)
        {
            return E1.Eval(env) + E2.Eval(env);
        }

        public override Expr Simplify()
        {
            var e1 = E1.Simplify();
            var e2 = E2.Simplify();
			
			if (e1.GetType () == typeof(CstI)) {
				if ((e1 as CstI).Value == 0)
					return e2;
			}

			if (e2.GetType () == typeof(CstI)) {
				if ((e2 as CstI).Value == 0)
					return e1;
			}
				
            return new Add(e1, e2);
        }
    }
    class Sub : Binop
    {
        public Sub(Expr e1, Expr e2) : base(e1, e2) { Symb = "-"; }
        public override int Eval(System.Collections.Generic.Dictionary<string, int> env)
        {
            return E1.Eval(env) - E2.Eval(env);
        }

        public override Expr Simplify()
        {
			var e1 = E1.Simplify();
			var e2 = E2.Simplify();

			if (e2.GetType () == typeof(CstI)) {
				if ((e2 as CstI).Value == 0){
						return e1;
				}
				else if(e1.GetType() == typeof(CstI) && (e2 as CstI).Value == (e1 as CstI).Value){
					return new CstI(0);
				}
			}
				
			return new Sub(e1, e2);
   		}
	}
    class Mul : Binop
    {
        public Mul(Expr e1, Expr e2) : base(e1, e2) { Symb = "*"; }
        public override int Eval(System.Collections.Generic.Dictionary<string, int> env)
        {
            return E1.Eval(env) * E2.Eval(env);
        }

        public override Expr Simplify()
        {
			var e1 = E1.Simplify();
			var e2 = E2.Simplify();

			if (e2.GetType () == typeof(CstI)) {
				if ((e2 as CstI).Value == 1){
					return e1;
				}
				if (e1.GetType () == typeof(CstI)) {
					if ((e1 as CstI).Value == 1) {
						return e2;
					} else if ((e2 as CstI).Value == 0 || (e1 as CstI).Value == 0) {
						return new CstI (0);
					}
				}
			}

			return new Mul(e1, e2);
        }  
    }
}

