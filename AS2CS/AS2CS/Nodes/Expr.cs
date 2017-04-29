using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Expr : Node
    {
        public Expr(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(new TokenNode(ts, TokenTypes.Number)))//PODO
            {
                //r float //PODO
                if (!Accept(new TokenNode(ts, TokenTypes.String)))//PODO
                {
                    //r regex//PODO
                    if (!Accept(N_TRUE)
                        && !Accept(N_FALSE)
                        && !Accept(N_NULL))
                    {
                        if (!Accept(new TokenNode(ts, TokenTypes.Keyword.Constant)))
                        {
                            if (!Accept<ArrayLiteral>())
                            {
                                //h
                            }
                        }
                    }
                }
            }
        }
    }
}
