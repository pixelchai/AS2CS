using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Comparer : Node
    {
        public Comparer(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<TokenNode>(TokenTypes.Operator)) return null;
            while (Accept<TokenNode>(TokenTypes.Operator)) { }
            return this;
        }
    }
}
