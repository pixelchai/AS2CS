using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    /// <summary>
    /// a
    /// </summary>
    public class Directives : Node
    {
        public Directives(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            while (Accept<Directive>()) { }
            return this;
        }
    }
}
