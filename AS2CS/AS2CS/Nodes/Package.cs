using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Package : Node
    {
        public Package(TokenStream ts) : base(ts) { }

        public override Node Select()
        {
            ts.SetSave(ts.tokens.Count - 2);
            return this;
        }
    }
}
