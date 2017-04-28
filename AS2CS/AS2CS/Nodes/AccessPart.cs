using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class AccessPart : Node
    {
        public bool IsThis = false;
        public bool IsAttribute = false;
        public bool IsSuper = false;

        public AccessPart(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(new TokenNode(ts, TokenTypes.Name.Attribute, TokenNode.VerificationMode.IsX)))
            {
                if (!Accept(new TokenNode(ts, TokenTypes.Name, TokenNode.VerificationMode.IsX)))
                {
                    if (!Accept(new TokenNode(ts, TokenTypes.Name.Function, TokenNode.VerificationMode.IsX)))
                    {
                        if (!Accept(new TokenNode(ts, TokenTypes.Keyword, "this")))
                        {
                            if (!Accept(new TokenNode(ts, TokenTypes.Keyword, "super")))
                            {
                                return null;
                            }
                            else
                            {
                                IsSuper = true;
                            }
                        }
                        else
                        {
                            IsThis = true;
                        }
                    }
                }
            }
            else
            {
                IsAttribute = true;
            }
            return this;
        }
    }
}
