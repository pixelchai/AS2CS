using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class MethodDeclaration : Node
    {
        public MethodDeclaration(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<Modifiers>()) return null;
            if (!Accept(N_FUNCTION)) return null;
            if (!Accept(N_GET)) Accept(N_SET); //opt or
            Expect(N_IDENTIFIER);
            Expect(N_LBRAC);
            Expect<Parameters>();//a
            Expect(N_RBRAC);
            Accept<TypeRelation>();//opt
            Expect<OptBody>();
            return this;
        }
    }
}
