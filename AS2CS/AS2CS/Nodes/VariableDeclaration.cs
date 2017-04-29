using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class VariableDeclaration : Node
    {
        public VariableDeclaration(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<ConstOrVar>()) return null;
            if (!Accept<IdentifierDeclaration>()) return null;
            while (Accept(N_COMMA))
            {
                Expect<IdentifierDeclaration>();
            }
            return this;
        }
    }
}
