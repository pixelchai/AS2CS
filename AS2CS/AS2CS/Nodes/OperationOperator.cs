using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class OperationOperator : Node
    {
        public OperationOperator(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (Accept(new TokenNode(ts, TokenTypes.Operator, "+"))) return this;
            if (Accept(new TokenNode(ts, TokenTypes.Operator, "-"))) return this;
            if (Accept(new TokenNode(ts, TokenTypes.Operator, "="))) return this;
            if (Accept(new TokenNode(ts, TokenTypes.Operator, "~"))) return this;
            if (Accept(new TokenNode(ts, TokenTypes.Operator, @"\"))) return this;
            if (Accept(new TokenNode(ts, TokenTypes.Operator, @"<"))) return this;
            if (Accept(new TokenNode(ts, TokenTypes.Operator, @">"))) return this;
            if (Accept(new TokenNode(ts, TokenTypes.Operator, @"^"))) return this;
            if (Accept(new TokenNode(ts, TokenTypes.Operator, @"!"))) return this;
            if (Accept(new TokenNode(ts, TokenTypes.Operator, @"&"))) return this;
            if (Accept(new TokenNode(ts, TokenTypes.Operator, @"%"))) return this;
            if (Accept(new TokenNode(ts, TokenTypes.Operator, @"|"))) return this;
            return null;
        }
    }
}
