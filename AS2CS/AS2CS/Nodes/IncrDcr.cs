using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class IncrDcr : Node
    {
        public bool needSemicolon = true;
        public IncrDcr(TokenStream tokenStream) : base(tokenStream)
        {
        }
        public IncrDcr(TokenStream tokenStream, bool needSemicolon = true) : base(tokenStream)
        {
            this.needSemicolon = needSemicolon;
        }

        public override Node Select()
        {
            if (!Accept<Access>()) return null;
            if (!Accept(new TokenNode(ts, TokenTypes.Operator, "+")))
            {
                if (!Accept(new TokenNode(ts, TokenTypes.Operator, "-")))
                {
                    return null;
                }
                else if (!Expect(new TokenNode(ts, TokenTypes.Operator, "-"))) return null;

            }
            else if (!Expect(new TokenNode(ts, TokenTypes.Operator, "+"))) return null;

            if(needSemicolon)
            if (!Expect(new TokenNode(ts, TokenTypes.Operator, ";"))) return null;
            return this;
        }
    }
}
