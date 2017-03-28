//http://stackoverflow.com/questions/996478/actionscript-is-there-ever-a-good-reason-to-use-as-casting

using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class As : Node
    {
        public bool needBrackets = true;
        public As(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (needBrackets) if (!Accept(new TokenNode(ts, TokenTypes.Operator, "("))) return null;
            if (!Accept<Expression>()) return null;
            if (!Accept(new TokenNode(ts, TokenTypes.Keyword, "as"))) return null;
            if (!Accept(new TokenNode(ts, TokenTypes.Name))) return null;
            if (needBrackets) if (!Accept(new TokenNode(ts, TokenTypes.Operator, ")"))) return null;
            return this;
        }
    }
}
