using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class MemberDeclaration : Node
    {
        public MemberDeclaration(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<FieldDeclaration>())
            {
                if (!Accept<MethodDeclaration>())
                {
                    return null;
                }
            }
            else
            {
                Expect(N_SEMICOLON);
            }
            return this;
        }
    }
}
