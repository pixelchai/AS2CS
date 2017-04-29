using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class PrefixOperator : Node
    {
        public PrefixOperator(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(new TokenNode(ts, "", "+")))
            {
                if (!Accept(new TokenNode(ts, "", "-")))
                {
                    if (!(Accept(new TokenNode(ts, "", "!"))||
                        Accept(new TokenNode(ts, "", "~")) ||
                        Accept(new TokenNode(ts, "", "typeof"))
                        ))
                    {
                        return null;
                    }
                }
                else
                {
                    Accept(new TokenNode(ts, "", "-"));//opt
                }
            }
            else
            {
                Accept(new TokenNode(ts, "", "+"));//opt
            }
            return this;
        }
    }
}
