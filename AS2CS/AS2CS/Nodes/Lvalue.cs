using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Lvalue : Node
    {
        public Lvalue(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<NamespacedIdentifier>())
            {
                if (!Accept<Expr>())
                {
                    if (!Accept(N_SUPER))
                    {
                        return null;
                    }
                    else
                    {
                        Expect(N_DOT);
                        Expect<NamespacedIdentifier>();
                    }
                }
                else
                {
                    if (!Accept(N_DOT))
                    {
                        Expect(N_LSQUARE);
                        Expect<CommaExpr>();
                        Expect(N_RSQUARE);
                    }
                    else
                    {
                        Expect<NamespacedIdentifier>();
                    }
                }
            }
            return this;
        }
    }
}
