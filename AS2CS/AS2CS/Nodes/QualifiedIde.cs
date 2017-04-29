using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class QualifiedIde : Node
    {
        protected QualifiedIde(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(N_IDENTIFIER)) return null;
            //while(Accept(new TokenNode(ts,TokenTypes)))
            throw new NotImplementedException();
        }
    }
}
