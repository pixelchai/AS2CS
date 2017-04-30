using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class StaticInitializer : Node
    {
        public StaticInitializer(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<Block>()) return null;
            return this;
        }
    }
}
