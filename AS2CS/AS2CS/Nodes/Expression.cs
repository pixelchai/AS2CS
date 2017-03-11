using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Expression : Node
    {
        public Expression(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(new TokenNode(ts, TokenTypes.Number)))
            {
                //if(!Accept(new TokenNode(ts,TokenTypes.)))
            }
            return this;
        }
    }
}
