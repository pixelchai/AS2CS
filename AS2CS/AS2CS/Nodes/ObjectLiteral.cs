using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class ObjectLiteral : Node
    {
        public ObjectLiteral(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(N_LCURLY)) return null;
            Accept<ObjectFields>();
            if (!Expect(N_RCURLY)) return null;
            return this;
        }
    }
}
