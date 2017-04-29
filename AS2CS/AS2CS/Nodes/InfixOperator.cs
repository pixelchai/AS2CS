using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class InfixOperator : Node
    {
        public static string[] InfixOperators = new string[] { @"=", @"*=", @"/=", @"%=", @"+=", @"-=", @"=", @">>>=", @"&=", @"^=", @"|=", @"||", @"&&", @"|", @"^", @"&", @"==", @"!=", @"===", @"!==", @"<", @">", @"=", @"as", @"in", @"instanceof", @"is", @">", @">>>", @"+", @"-", @"*", @"/", @"%", @".", @"::" };

        public InfixOperator(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            foreach (string op in InfixOperators)
            {
                bool ya = true;
                foreach (char c in op)
                {
                    if (!Accept(new TokenNode(ts, "", "" + c)))
                    {
                        ya = false;
                        break;
                    }
                }
                if (ya) return this;
            }
            return null;
        }
    }
}
