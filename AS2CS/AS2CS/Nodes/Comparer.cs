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
            //if (!Accept(new TokenNode(ts,TokenTypes.Operator))) return null;
            //while (Accept(new TokenNode(ts, TokenTypes.Operator))) { }
            if (!Accept<OperationOperator>()) return null;
            while (Accept<OperationOperator>()) { }
            return this;
        }
    }
}
