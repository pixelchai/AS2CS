using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Block : Node
    {
        public Block(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(N_LCURLY)) return null;
            Expect<Statements>();
            if (!Expect(N_RCURLY)) return null;
            return this;
        }
    }
}
