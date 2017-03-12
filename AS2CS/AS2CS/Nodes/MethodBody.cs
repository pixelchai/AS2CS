using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class MethodBody : Node
    {
        public MethodBody(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            while (Accept<Statement>()) { }
            return this;
        }
    }
}
