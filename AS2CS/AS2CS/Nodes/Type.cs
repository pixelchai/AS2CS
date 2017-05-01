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
            //ad
            bool bracketed = Accept(N_LPOINTY);
            if (!Accept<QualifiedIde>())
            {
                if (!Accept(N_ASTERISK))//q
                {
                    if (!Accept(N_VOID))
                    {
                        return null;
                    }
                }
            }
            if (bracketed) Expect(N_RPOINTY);
            return this;
        }
    }
}
