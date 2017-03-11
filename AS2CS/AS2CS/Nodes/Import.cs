using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Import : Node
    {
        public Import(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!base.Accept(new TokenNode(ts, TokenTypes.Keyword, "import"))) return null;
            if (!base.Expect(new TokenNode(ts, TokenTypes.Name.Namespace))) return null;
            if (!base.Expect(new TokenNode(ts, TokenTypes.Operator, ";"))) return null;
            return this;
        }
    }
}
