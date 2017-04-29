using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class CommaExpr : Node
    {
        public CommaExpr(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<Expr>()) return null;
            while (Accept(TokenNode.Comma(ts)))
            {
                Accept<Expr>();
            }
            return this;
        }
    }
}
