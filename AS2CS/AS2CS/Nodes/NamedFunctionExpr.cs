using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class NamedFunctionExpr : Node
    {
        public NamedFunctionExpr(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(new TokenNode(ts, TokenTypes.Keyword, "function"))) return null;
            Expect(new TokenNode(ts, TokenTypes.Name));
            Expect(new TokenNode(ts, "", "("));
            Expect<Parameters>();
            Expect(new TokenNode(ts, "", ")"));
            //optional
            Accept<TypeRelation>();
            //h block
        }
    }
}
