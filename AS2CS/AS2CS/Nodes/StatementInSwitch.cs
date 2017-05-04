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
            //if (!Accept<Statement>())
            //{
            //    if (!Accept(N_CASE))
            //    {
            //        if (!Accept(N_DEFAULT))
            //        {
            //            return null;
            //        }
            //        else
            //        {
            //            Expect(N_COLON);
            //        }
            //    }
            //    else
            //    {
            //        if (!Expect<BExpr>()) return null;
            //        Expect(N_COLON);
            //    }
            //}
            if (!Accept(N_DEFAULT))
            {
                if (!Accept(N_CASE))
                {
                    if (!Accept<Statement>())
                    {
                        return null;
                    }
                }
                else
                {
                    if (!Expect<BExpr>()) return null;
                    Expect(N_COLON);
                }
            }
            else
            {
                Expect(N_COLON);
            }
            return this;
        }
    }
}
