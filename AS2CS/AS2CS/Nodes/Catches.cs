using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Catches : Node
    {
        public Catches(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            while (Accept(N_CATCH))
            {
                if (!Accept(N_LBRAC))//q! //CHECK //should be opt?
                    return null;
                Expect<Parameter>();
                Expect(N_RBRAC);
                Expect<Block>();
            }
            return this;
        }
    }
}
