using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Parameter : Node
    {
        public Parameter(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            Accept(new TokenNode(ts, TokenTypes.Keyword, "const"));//opt
            if (!Accept(new TokenNode(ts, TokenTypes.Name))) return null;
            Accept<TypeRelation>();//optional
            //optional
            if (Accept(new TokenNode(ts, "", "=")))
            {
                Expect<ExprOrObjectLiteral>();
            }
            return this;
        }
    }
}
