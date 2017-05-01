using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class ExprOrObjectLiteral : Node
    {
        public ExprOrObjectLiteral(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<BExpr>())
            {
                if (!Accept<ObjectLiteral>())
                {
                    if (!Accept<NamedFunctionExpr>())
                    {
                        return null;
                    }
                }
            }
            return this;
        }
    }
}
