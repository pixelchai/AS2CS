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
                    if (!Accept(new TokenNode(ts, TokenTypes.Keyword, "true"))
                        && !Accept(new TokenNode(ts, TokenTypes.Keyword, "false"))
                        && !Accept(new TokenNode(ts, TokenTypes.Keyword, "null")))
                    {
                        if (!Accept(new TokenNode(ts, TokenTypes.Keyword.Constant)))
                        {
                            //TODO //h
                        }
                    }
                }
            }
        }
    }
}
