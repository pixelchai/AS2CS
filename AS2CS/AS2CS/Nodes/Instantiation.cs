using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Instantiation : Node
    {
        public bool TypeIsGeneric = false;
        public string Type = null;
        public Instantiation(TokenStream tokenStream) : base(tokenStream)
        {
        } 

        public override Node Select()
        {
            if (!Accept(new TokenNode(ts, TokenTypes.Keyword, "new"))) return null;
            if (!Accept(new TokenNode(ts, TokenTypes.Keyword.Type)))
            {
                if (!Accept(new TokenNode(ts, TokenTypes.Operator, "<")))
                {
                    if (!Expect<Access>()) return null;
                }
                else {
                    TypeIsGeneric = true;
                    if (!Expect(new TokenNode(ts, TokenTypes.Name)))
                    {
                        return null;
                    }
                    else
                    {
                        Type = ((TokenNode)base.lastAccepted).GetValue();
                    }
                    if (!Expect(new TokenNode(ts, TokenTypes.Operator, ">"))) return null;
                }
                
            }
            else
            {
                Type = ((TokenNode)base.lastAccepted).GetValue();
            }

            if (!Accept(new TokenNode(ts, TokenTypes.Operator, "(")))
            {
                if (!Expect(new TokenNode(ts, TokenTypes.Operator, "["))) return null;
            }

            if (!Expect<ParamsSend>()) return null;

            if (!Accept(new TokenNode(ts, TokenTypes.Operator, ")")))
            {
                if (!Expect(new TokenNode(ts, TokenTypes.Operator, "]"))) return null;
            }
            return this;
        }
    }
}
