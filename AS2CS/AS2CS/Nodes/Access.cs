using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Access : Node
    {
        public bool attr { get; private set; } = false;
        public bool enclosed { get; private set; } = false;

        public Access(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (Accept(new TokenNode(ts, TokenTypes.Operator, "("))) enclosed = true;
            Accept<OperationOperator>();
            Accept<AccessPart>();
            while ((Accept(new TokenNode(ts, TokenTypes.Operator, "."))))
            {
                if (Accept(new TokenNode(ts, TokenTypes.Punctuation, "@")))
                {
                    attr = true;
                }

                Expect<AccessPart>();
            }
            if (enclosed)
            {
                if (!Accept(new TokenNode(ts, TokenTypes.Operator, ")"))) return null;
            }
            return this;
        }
    }
}
