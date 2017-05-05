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
            bool pbrac = Accept(N_LPOINTY);
            bool brac = Accept(N_LBRAC);
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
            else
            {
                //for weird vector.<Number> types
                if (Accept(N_LPOINTY))
                {
                    Expect(N_IDENTIFIER);
                    Expect(N_RPOINTY);
                }
            }
            if (pbrac && !Accept(N_RPOINTY)) return null;
            if (brac&& !Accept(N_RBRAC)) return null;
            return this;
        }
    }
}
