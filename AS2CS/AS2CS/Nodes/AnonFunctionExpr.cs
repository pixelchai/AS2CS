using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class AnonFunctionExpr : Node
    {
        public AnonFunctionExpr(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(N_FUNCTION)) return null;
            if (!Accept(N_LBRAC)) return null;
            Expect<Parameters>();
            Expect(N_RBRAC);
            Accept<TypeRelation>();//opt
            Expect<Block>();
            return this;
        }
    }
}
