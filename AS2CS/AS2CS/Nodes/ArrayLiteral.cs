using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class ArrayLiteral : Node
    {
        protected ArrayLiteral(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(new TokenNode(ts, "", "["))) return null;
            //h arguments
            if (!Expect(new TokenNode(ts, "", "]"))) return null;
        }
    }
}
