using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class SkipBrac : Node
    {
        public string LBRAC = "(";
        public string RBRAC = ")";

        public bool accept = true;
        private string value = "";

        public override string GetValue()
        {
            return value;
        }

        public SkipBrac(TokenStream tokenStream, bool accept) : base(tokenStream)
        {
            this.accept = accept;
        }

        public SkipBrac(TokenStream tokenStream, string lbrac = "(", string rbrac = ")", bool accept = true) : base(tokenStream)
        {
            this.LBRAC = lbrac;
            this.RBRAC = rbrac;
            this.accept = accept;
        }

        public override Node Select()
        {
            int depth = 0;
            if (!Accept(new TokenNode(ts, TokenTypes.Operator,LBRAC))) return null;
            else depth++;
            while (depth > 0)
            {
                if (Accept(new TokenNode(ts, TokenTypes.Operator, LBRAC)))
                {
                    depth++;
                }
                else if (Accept(new TokenNode(ts, TokenTypes.Operator, RBRAC)))
                {
                    depth--;
                }
                else
                {
                    children.Add(new TokenNode(ts.getCur()));
                    ts.increment();
                }

            }
            return this;
        }
    }
}
