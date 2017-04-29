using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class StatementInSwitch : Node
    {
        public StatementInSwitch(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<Statement>())
            {
                if (!Accept(N_CASE))
                {
                    if (!Accept(N_DEFAULT))
                    {
                    }
                    else
                    {
                        //h
                    }
                }
                else
                {
                    if (!Expect<Expr>()) return null;
                    Expect(N_COLON);
                }
            }
        }
    }
}
