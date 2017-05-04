using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    /// <summary>
    /// a
    /// </summary>
    public class Arguments : Node
    {
        public Arguments(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            //optional
            if (Accept<ExprOrObjectLiteral>())
            {
                while (Accept(N_COMMA))
                {
                    Expect<ExprOrObjectLiteral>();
                }
            }
            return this;
        }
    }
}
