using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class FieldDeclaration : Node
    {
        public FieldDeclaration(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<Modifiers>()) return null;//a
            if (!Accept<ConstOrVar>()) return null;
            Expect<IdentifierDeclaration>();
            while (Accept(N_COMMA))
            {
                Expect<IdentifierDeclaration>();
            }
            return this;
        }
    }
}
