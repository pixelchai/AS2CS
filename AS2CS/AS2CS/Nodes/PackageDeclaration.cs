using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class PackageDeclaration : Node
    {
        public PackageDeclaration(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(new TokenNode(ts, TokenTypes.Keyword, "package"))) return null;
            Accept(new TokenNode(ts, TokenTypes.Name.Namespace)); //optional //added
            return this;
        }
    }
}
