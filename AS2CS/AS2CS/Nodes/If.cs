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
            try
            {
                Expect<Condition>();
            }
            catch
            {
                    if (Utils.LAZY)
                    {
                        if (!Accept(new SkipUntil(ts, new TokenNode(ts, TokenTypes.Operator, ")"), true))) return null;
                    }
                    else
                    {
                        throw new Exceptions.CompilerException(ts);
                    }
            }
            if (!Expect(new TokenNode(ts, TokenTypes.Operator, ")"))) return null;
            if (!Expect(new TokenNode(ts, TokenTypes.Operator, "{"))) return null;
            Accept<MethodBody>();
            if (!Expect(new TokenNode(ts, TokenTypes.Operator, "}"))) return null;
            return this;
        }
    }
}
