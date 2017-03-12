using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Call : Node
    {
        public bool needSemicolon = true;
        public Call(TokenStream tokenStream) : base(tokenStream)
        {
        }
        public Call(TokenStream tokenStream, bool needSemicolon = true) : base(tokenStream)
        {
            this.needSemicolon = needSemicolon;
        }

        public override Node Select()
        {
            if (!Accept<Access>()) return null;
            if (!Expect(new TokenNode(ts, TokenTypes.Operator, "("))) return null;
            Accept<ParamsSend>();
            if (!Expect(new TokenNode(ts, TokenTypes.Operator, ")"))) return null;
            if (needSemicolon)
                if (!Expect(new TokenNode(ts, TokenTypes.Operator, ";"))) return null;
            return this;
        }
    }
}
