using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Directive : Node
    {
        public Directive(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(N_IMPORT))
            {
                if (!Accept(N_LSQUARE))
                {
                    if (!Accept(N_USE))
                    {
                        if (!Accept(N_SEMICOLON)) return null;//q
                    }
                    else
                    {
                        if (!Expect(N_IDENTIFIER)) return null;
                        if (!Expect<Type>()) return null;
                    }
                }
                else
                {
                    if (!Expect(N_IDENTIFIER)) return null;
                    //optional
                    if (Accept(N_LBRAC))
                    {
                        Expect<AnnotationFields>();
                        Expect(N_RBRAC);
                    }
                    if (!Expect(N_RSQUARE)) return null;
                }
            }
            else
            {
                Expect(N_NAMESPACE); //ad //PODO: *s
                Expect(N_SEMICOLON);
            }
            return this;
        }
    }
}
