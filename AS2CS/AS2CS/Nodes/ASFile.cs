using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class ASFile : Node
    {
        public ASFile(TokenStream ts) : base(ts) { }

        public override Node Select()
        {
            if (base.Accept(new ASFile(ts)))
            {
            }
            return null;//TODO
        }
    }
}
