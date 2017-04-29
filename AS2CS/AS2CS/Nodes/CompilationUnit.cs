using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class CompilationUnit : Node
    {
        public CompilationUnit(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            Expect<PackageDeclaration>();
            Expect(new TokenNode(ts, "", "{"));
            Accept<Directives>(); //a

        }
    }
}
