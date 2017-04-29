using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Parameter : Node
    {
        public Parameter(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            Accept(N_CONST);//opt
            if (!Accept(N_IDENTIFIER)) return null;
            Accept<TypeRelation>();//optional
            //optional
            if (Accept(N_EQUALS))
            {
                Expect<ExprOrObjectLiteral>();
            }
            return this;
        }
    }
}
