using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Return : Node
    {
        public bool ReturnVoid { get; private set; } = false;
        public bool NeedBrackets { get; private set; } = false;
        public Return(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(new TokenNode(ts, TokenTypes.Keyword, "return"))) return null;
            if (Accept(new TokenNode(ts, TokenTypes.Operator, ";")))
            {
                this.ReturnVoid = true;
                return this;
            }
            else
            {
                if (Accept(new TokenNode(ts, TokenTypes.Operator, "("))) NeedBrackets = true;
                if (!Accept<Expression>()) return null;
                if (NeedBrackets)
                {
                    if (!Expect(new TokenNode(ts, TokenTypes.Operator, ")"))) return null;
                }
                return this;
            }

        }
    }
}
