using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Conditional : Node
    {
        public Conditional(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            //TODO: case
            if (!Accept<If>())
            {
                //case
                return null;
            }
            Accept<Else>();
            return this;
        }
    }
}
