using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    /// <summary>
    /// DEPRECATED
    /// </summary>
    public class InfixOperator : Node
    {
        public static string[] InfixOperators = new string[] { /*@".",*/ @"instanceof", @">>>=", @"!==", @"===", @">>>", @"||", @"as", @"^=", @"/=", @"in", @"is", @"%=", @"&=", @"-=", @"==", @"&&", @"+=", @"|=", @"!=", @"*=",@">=",@"<=", @"^", @">", @">", @"|", @"=", @"=", @"<", @"%", @"/", @".", @"-", @"+", @"*", @"&", @"=", @"::" };


        public InfixOperator(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {//this.GetValue().ToLower().Contains("ip")
            throw new InvalidOperationException();
            foreach (string op in InfixOperators)
            {
                bool ya = true;
                int no = 0;
                foreach (char c in op)
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
                if (ya) return this;
                else if(no>0){ base.ts.increment(no * -1); Debug.WriteLine("Infix Undo: " + op + "! (x" + no + ")"); }
            }
            return null;
        }
    }
}
