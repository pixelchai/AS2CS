using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class ForEach : Node
    {
        public ForEach(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(new TokenNode(ts, TokenTypes.Keyword, "for"))) return null;
            if (!Accept(new TokenNode(ts, TokenTypes.Keyword, "each"))) return null;
            if (!Accept(new TokenNode(ts, TokenTypes.Operator, "("))) return null;
            if (!Accept<InExpression>()) return null;//PROBLEM HERE
            if (!Accept(new TokenNode(ts, TokenTypes.Operator, ")"))) return null;
            if (!Accept(new TokenNode(ts, TokenTypes.Operator, "{"))) return null;
            if (!Accept<MethodBody>()) return null;
            if (!Accept(new TokenNode(ts, TokenTypes.Operator, "}"))) return null;
            return this;
        }
    }
}
