    class MathSyntax
    {
        static void Main(string[] args)
        {

            var env = new System.Collections.Generic.Dictionary<string, int>();
            env.Add("z",5);
            env.Add("x",2);

            Expr e1 = new Add(new CstI(17), new Var("z")).Simplify(env);
            Expr e2 = new Mul(new Var("x"), new Var("z")).Simplify(env);
            Expr e3 = new Sub(new Mul(new CstI(17), new CstI(5)), new Var("z")).Simplify(env);
            Expr e4 = new Add(new CstI(17), new CstI(0)).Simplify(env);

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
            Expr Simplify(System.Collections.Generic.Dictionary<string, int> env);
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

            public Expr Simplify(System.Collections.Generic.Dictionary<string, int> env)
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

            public Expr Simplify(System.Collections.Generic.Dictionary<string, int> env)
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

            public abstract Expr Simplify(System.Collections.Generic.Dictionary<string, int> env);
        }

        class Add : Binop
        {
            public Add(Expr e1, Expr e2) : base(e1, e2) { Symb = "+"; }
            public override int Eval(System.Collections.Generic.Dictionary<string, int> env)
            {
                return E1.Eval(env) + E2.Eval(env);
            }

            public override Expr Simplify(System.Collections.Generic.Dictionary<string, int> env)
            {
                var e1 = E1.Simplify(env);
                var e2 = E2.Simplify(env);

                if (e1.Eval(env) == 0) return e2;
                if (e2.Eval(env) == 0) return e1;
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

            public override Expr Simplify(System.Collections.Generic.Dictionary<string, int> env)
            {
                var e1 = E1.Simplify(env);
                var e2 = E2.Simplify(env);

                if (e2.Eval(env) == 0) return e1;
                if (e2.Eval(env) == e1.Eval(env)) return new CstI(0);
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

            public override Expr Simplify(System.Collections.Generic.Dictionary<string, int> env)
            {
                var e1 = E1.Simplify(env);
                var e2 = E2.Simplify(env);
                var e1eval = e1.Eval(env);
                var e2eval = e2.Eval(env);

                if (e1eval == 0 || e2eval == 0) return new CstI(0);
                if (e2eval == 1) return e1;
                if (e1eval == 1) return e2;
                return new Mul(e1, e2);
            }  
        }
    }
