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
    public class AnnotationFields : Node
    {
        public AnnotationFields(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            //optional
            if (Accept<AnnotationField>())
            {
                while (Accept(new TokenNode(ts, "", ",")))
                {
                    Expect<AnnotationField>();
                }
            }
            return this;
        }
    }
}
