using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Access : Node
    {
        public bool attr { get; private set; } = false;

        public Access(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            Accept(new TokenNode(ts, TokenTypes.Operator,"-"));//- or +
            Accept(new TokenNode(ts, TokenTypes.Operator,"+"));//- or +
            Accept<AccessPart>();
            while ((Accept(new TokenNode(ts, TokenTypes.Operator, "."))))
            {
                if (Accept(new TokenNode(ts, TokenTypes.Punctuation, "@")))
                {
                    attr = true;
                }

                Expect<AccessPart>();
            }
            return this;
        }
    }
}
