using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class NamespacedIdentifier : Node
    {
        public NamespacedIdentifier(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (Accept<Modifier>())//opt
            {
                Expect(N_COLON);
                Expect(N_COLON);
            }
            if (!Accept(N_IDENTIFIER)) return null;
            return this;
        }
    }
}
