using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class TypeRelation : Node
    {
        public TypeRelation(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(N_COLON)) return null;
            Expect<Type>();
            return this;
        }
    }
}
