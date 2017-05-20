using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class CompilationUnitDeclaration : Node
    {
        public CompilationUnitDeclaration(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            //TODO: interface
            if (!Accept<ClassDeclaration>())
            {
                if (!Accept<MemberDeclaration>()) return null;
            }
            return this;
        }
    }
}
