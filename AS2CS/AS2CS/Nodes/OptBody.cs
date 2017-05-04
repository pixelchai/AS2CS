using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class OptBody : Node
    {
        public OptBody(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<Block>())
            {
                if (!Accept(N_SEMICOLON)) return null;
            }
            return this;
        }
    }
}
