using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class ParamsSend : Node
    {
        public ParamsSend(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            Accept<Expression>();
            while ((Accept(new TokenNode(ts,TokenTypes.Operator,","))))
            {
                Expect<Expression>();
            }
            return this;
        }
    }
}
