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
            if (!Accept(new TokenNode(ts, TokenTypes.Keyword, "import")))
            {
                Expect(new TokenNode(ts, TokenTypes.Name.Namespace)); //ad //PODO: *s
            }
            else
            {
                if (!Accept(new TokenNode(ts, "", "[")))
                {
                    if (!Accept(new TokenNode(ts, "", "use")))//FIXME
                    {
                        if (!Accept(new TokenNode(ts, "", ";"))) return null;//q
                    }
                    else
                    {
                        if (!Expect(new TokenNode(ts, TokenTypes.Name))) return null;
                        if (!Expect<Type>()) return null;
                    }
                }
                else
                {
                    if (!Expect(new TokenNode(ts, TokenTypes.Name))) return null;
                    //optional
                    if (Accept(new TokenNode(ts, "", "(")))
                    {
                        Expect<AnnotationFields>();
                        Expect(new TokenNode(ts, "", ")"));
                    }
                    if (!Expect(new TokenNode(ts, "", "]"))) return null;
                }
            }
            return this;
        }
    }
}
