using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Modifiers : Node
    {
        public Modifiers(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            while (!Accept<Modifier>())
            {
            }
            return this;
        }
    }
}
