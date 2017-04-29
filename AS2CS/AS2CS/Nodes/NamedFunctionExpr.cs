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
            if (!Accept(N_FUNCTION)) return null;
            Expect(N_IDENTIFIER);
            Expect(N_LBRAC);
            Expect<Parameters>();
            Expect(N_RBRAC);
            //optional
            Accept<TypeRelation>();
            Expect<Block>();
            return this;
        }
    }
}
