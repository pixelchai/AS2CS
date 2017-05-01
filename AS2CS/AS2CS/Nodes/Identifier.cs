using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Identifier : Node
    {
        public bool IsAttr = false;
        public Identifier(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            IsAttr = Accept(N_AT);
            if (!Accept(new TokenNode(this.ts, TokenTypes.Name)))
            {
                if (!Accept(new TokenNode(this.ts, TokenTypes.Keyword.Type)))//ad due to Type using "identifier"
                {
                    return null;
                }
            }
            return this;
        }
    }
}
