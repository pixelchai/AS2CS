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
        public Access(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            Accept<AccessPart>();
            while ((Accept(new TokenNode(ts, TokenTypes.Operator, "."))))
            {
                Expect<AccessPart>();
            }
            return this;
        }
    }
}
