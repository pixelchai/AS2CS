using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class ClassDeclaration : Node
    {
        public ClassDeclaration(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<Modifiers>()) return null;//a
            if (!Accept(N_CLASS)) return null;
            Expect(N_IDENTIFIER);
            if (Accept(N_EXTENDS))//opt
            {
                Expect<Type>();
            }
            if (Accept(N_IMPLEMENTS))//opt
            {
                Expect<Type>();
                while (Accept(N_COMMA))
                {
                    Expect<Type>();
                }
            }
            Expect<ClassBody>();
            return this;
        }
    }
}
