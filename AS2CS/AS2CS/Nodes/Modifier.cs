using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Modifier : Node
    {
        public Modifier(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!(Accept(N_PUBLIC) ||
                Accept(N_PROTECTED)||
                Accept(N_PRIVATE)||
                Accept(N_STATIC)||
                Accept(N_ABSTRACT)||
                Accept(N_FINAL)||
                Accept(N_OVERRIDE)||
                Accept(N_INTERNAL)
                )) return null;
            return this;
        }
    }
}
