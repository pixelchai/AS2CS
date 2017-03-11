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
        public static TokenType[] types = new TokenType[]
        {
            TokenTypes.Number,
            TokenTypes.String,
        };

        public Expression(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            foreach (TokenType type in types)
            {
                if(Accept(new TokenNode(ts, type)))
                {
                    return this;
                }
            }
            Skip();
            return this;
        }

        private void Skip()
        {
            Accept(new SkipUntil(ts, new TokenNode(ts, TokenTypes.Operator, ";"), true));
        }
    }
}
