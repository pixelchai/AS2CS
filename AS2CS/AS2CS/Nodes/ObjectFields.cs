using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class ObjectFields : Node
    {
        public ObjectFields(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            //optional
            if (Accept<ObjectField>())
            {
                while (Accept(new TokenNode(ts, "", ",")))
                {
                    Expect<ObjectField>();
                }
            }
            return this;
        }
    }
}
