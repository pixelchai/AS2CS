using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class ArrayLiteral : Node
    {
        public ArrayLiteral(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(N_LSQUARE)) return null;
            Accept<Arguments>();
            if (!Expect(N_RSQUARE)) return null;
            return this;
        }
    }
}
