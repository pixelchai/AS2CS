using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class ParamsRecv : Node
    {
        public ParamsRecv(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            Accept<Parameter>();
            while ((Accept(new TokenNode(ts, TokenTypes.Operator, ","))))
            {
                Expect<Parameter>();
            }
            return this;
        }
    }
}
