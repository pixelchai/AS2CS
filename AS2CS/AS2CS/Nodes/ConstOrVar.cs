using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class ConstOrVar : Node
    {
        public ConstOrVar(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(N_CONST))
            {
                if (!Accept(N_VAR)) return null;
            }
            return this;
        }
    }
}
