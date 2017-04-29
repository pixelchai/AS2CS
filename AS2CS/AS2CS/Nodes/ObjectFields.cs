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
                while (Accept(N_COMMA))
                {
                    Expect<ObjectField>();
                }
            }
            return this;
        }
    }
}
