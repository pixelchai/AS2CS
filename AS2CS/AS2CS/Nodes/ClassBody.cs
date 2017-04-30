using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class ClassBody : Node
    {
        public ClassBody(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(N_LCURLY)) return null;
            while (Accept<Directive>() ||
                Accept<MemberDeclaration>() ||
                Accept<StaticInitializer>()
                ) { }
            Expect(N_RCURLY);
            return this;
        }
    }
}
