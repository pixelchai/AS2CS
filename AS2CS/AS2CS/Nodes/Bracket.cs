using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Bracket : Node
    {
        public Bracket(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            //Expression will use this
        }
    }
}
