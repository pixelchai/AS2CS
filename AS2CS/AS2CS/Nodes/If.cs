using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class If : Node
    {
        public If(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(new TokenNode(ts, TokenTypes.Keyword, "if"))) return null;
            if (!Expect(new TokenNode(ts, TokenTypes.Operator, "("))) return null;
            if (!Expect<Condition>()) return null;
            if (!Expect(new TokenNode(ts, TokenTypes.Operator, ")"))) return null;
            if (!Expect(new TokenNode(ts, TokenTypes.Operator, "{"))) return null;
            Accept<MethodBody>();
            if (!Expect(new TokenNode(ts, TokenTypes.Operator, "}"))) return null;
            return this;
        }
    }
}
