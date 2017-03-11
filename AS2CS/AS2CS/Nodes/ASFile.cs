using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class ASFile : Node
    {
        public ASFile(TokenStream ts) : base(ts) { }

        public override Node Select()
        {
            if (!base.Expect(new TokenNode(ts, TokenTypes.Keyword, "package"))) return null;
            if (!base.Expect(new TokenNode(ts, TokenTypes.Name.Namespace))) return null;
            if (!base.Expect(new TokenNode(ts, TokenTypes.Operator, "{"))) return null;
            if (!base.Accept<Package>()) return null;
            if (!base.Expect(new TokenNode(ts, TokenTypes.Operator, "}"))) return null;
            return this;
        }
    }
}
