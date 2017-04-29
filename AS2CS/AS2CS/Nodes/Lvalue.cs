using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Lvalue : Node
    {
        public Lvalue(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            //h namespacedIdentifier
        }
    }
}
