using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Type : Node
    {
        public Type(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<QualifiedIde>())
            {
                if (!Accept(new TokenNode(ts, "", "*")))//q
                {
                    if (!Accept(new TokenNode(ts, TokenTypes.Keyword, "void")))
                    {
                        return null;
                    }
                }
            }
            return this;
        }
    }
}
