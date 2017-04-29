using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class PostfixOperator : Node
    {
        public PostfixOperator(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (Accept(new TokenNode(ts, "", "+")) && Accept(new TokenNode(ts, "", "+"))) return this;
            if (Accept(new TokenNode(ts, "", "-")) && Accept(new TokenNode(ts, "", "-"))) return this;
            return null;
        }
    }
}
