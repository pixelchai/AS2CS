using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class ObjectField : Node
    {
        public ObjectField(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(new TokenNode(ts, TokenTypes.Name))
                && !Accept(new TokenNode(ts, TokenTypes.String))
                && !Accept(new TokenNode(ts, TokenTypes.Number)))
            {
                return null;
            }
            else
            {
                if (!Accept(new TokenNode(ts, "", ":"))) return null;
                if (!Accept<ExprOrObjectLiteral>()) return null;
            }
            return this;

        }
    }
}
