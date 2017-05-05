using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public struct InfixOrPostfix
    {
        public string Operator;
        public bool IsInfix;

        public InfixOrPostfix(string str, bool isinfix=true)
        {
            Operator = str;
            IsInfix = isinfix;
        }
    }

    public class InfixOrPostfixOperator : Node
    {
        public static InfixOrPostfix[] Operators = new InfixOrPostfix[] {
            new InfixOrPostfix(@"instanceof"),
                    new InfixOrPostfix(@">>>="),
            new InfixOrPostfix(@"!=="),
            new InfixOrPostfix(@"==="),
            new InfixOrPostfix(@">>>"),
            new InfixOrPostfix(@"++",false),
            new InfixOrPostfix(@"--",false),
            new InfixOrPostfix(@"||"),
            new InfixOrPostfix(@"as"),
            new InfixOrPostfix(@"^="),
            new InfixOrPostfix(@"/="),
            new InfixOrPostfix(@"in"),
            new InfixOrPostfix(@"is"),
            new InfixOrPostfix(@"%="),
            new InfixOrPostfix(@"&="),
            new InfixOrPostfix(@"-="),
            new InfixOrPostfix(@"=="),
            new InfixOrPostfix(@"&&"),
            new InfixOrPostfix(@"+="),
            new InfixOrPostfix(@"|="),
            new InfixOrPostfix(@"!="),
            new InfixOrPostfix(@"*="),
            new InfixOrPostfix(@">="),
            new InfixOrPostfix(@"<="),
            new InfixOrPostfix(@"^"),
            new InfixOrPostfix(@">"),
            new InfixOrPostfix(@">"),
            new InfixOrPostfix(@"|"),
            new InfixOrPostfix(@"="),
            new InfixOrPostfix(@"="),
            new InfixOrPostfix(@"<"),
            new InfixOrPostfix(@"%"),
            new InfixOrPostfix(@"/"),
            new InfixOrPostfix(@"."),
            new InfixOrPostfix(@"-"),
            new InfixOrPostfix(@"+"),
            new InfixOrPostfix(@"*"),
            new InfixOrPostfix(@"&"),
            new InfixOrPostfix(@"="),
            new InfixOrPostfix(@"::")
        };

        public InfixOrPostfixOperator(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            foreach (InfixOrPostfix op in Operators)
            {
                bool ya = true;
                int no = 0;
                foreach (char c in op.Operator)
                {
                    if (!Accept(new TokenNode(ts, "", "" + c)))
                    {
                        ya = false;
                        break;
                    }
                    else
                    {
                        no += base.lastAccepted.OffAmount();
                    }
                }
                if (ya)
                {
                    if (op.IsInfix)
                    {
                        if (!Accept<Type>())//ad for Vector.<x>
                        {
                            Expect<BExpr>();
                        }
                    }
                    return this;
                }
                else if (no > 0) {
                    base.ts.increment(no * -1);
                    if(Utils.DEBUG_PARSING)Debug.WriteLine("Operator Undo: " + op + "! (x" + no + ")");
                }
            }
            return null;
        }
    }
}
