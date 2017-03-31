using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Expression will use this


namespace AS2CS.Nodes
{
    public class Bracket<T> : Node where T : Node
    {
        public string LBRAC = "(";
        public string RBRAC = ")";

        public Bracket(TokenStream tokenStream, string lbrac = "(", string rbrac = ")") : base(tokenStream)
        {
            this.LBRAC = lbrac;
            this.RBRAC = rbrac;
        }

        public override Node Select()
        {
            if (!Accept(new TokenNode(ts, TokenTypes.Operator, LBRAC))) return null;
            if (!Accept<T>()) return null;
            if (!Accept(new TokenNode(ts, TokenTypes.Operator, RBRAC))) return null;
            return this;
        }
    }

    public class Bracket : Bracket<Expression>
    {
        public Bracket(TokenStream tokenStream, string lbrac = "(", string rbrac = ")") : base(tokenStream, lbrac, rbrac) { }
    }
}
