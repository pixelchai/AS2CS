using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Loop : Node
    {
        public Loop(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            //TODO: for, for...in, for each...in, while, do...while
            if (!Accept<ForEach>())
            {
                return null;
            }
            return this;
        }
    }
}
