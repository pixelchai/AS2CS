using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Statement : Node
    {
        public Statement(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<Call>())
            {
                if (!Accept<Variable>())
                {
                    if (!Accept<IncrDcr>())
                    {
                        if (!Accept<Conditional>())
                        {
                            //todo
                            Skip();
                        }
                    }
                }
            }
            return this;
        }

        private void Skip()
        {
            Accept(new SkipUntil(ts, new TokenNode(ts, TokenTypes.Operator, ";"), true));
        }
    }
}
