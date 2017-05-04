using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class IdentifierDeclaration : Node
    {
        public IdentifierDeclaration(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(N_IDENTIFIER)) return null;
            Accept<TypeRelation>();//optional
            if (Accept(N_EQUALS))//optional
            {
                Expect<ExprOrObjectLiteral>();
            }
            return this;
        }
    }
}
