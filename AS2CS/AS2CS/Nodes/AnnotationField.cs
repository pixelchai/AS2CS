using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class AnnotationField : Node
    {
        public AnnotationField(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            //CHECK
            Expect(N_IDENTIFIER);
            Expect(N_EQUALS);
            //TODO //h
        }
    }
}
