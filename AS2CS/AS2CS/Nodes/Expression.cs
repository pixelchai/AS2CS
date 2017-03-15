using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Expression : Node
    {
        public static TokenType[] types = new TokenType[]
        {
            TokenTypes.Number,
            TokenTypes.String,
            TokenTypes.Keyword.Constant,
        };

        /// <summary>
        /// NB: never reads semicolon
        /// </summary>
        /// <param name="tokenStream"></param>
        public Expression(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            Accept(new TokenNode(ts, TokenTypes.Operator, "+"));//- or +
            Accept(new TokenNode(ts, TokenTypes.Operator, "-"));//- or +
            foreach (TokenType type in types)
            {
                if(Accept(new TokenNode(ts, type)))
                {
                    return this;
                }
            }
            if (!Accept<Instantiation>())
            {
                //Skip();
                if (!Accept<Call>(false))
                {
                    //if (!Accept(new TokenNode(ts, TokenTypes.Name)))
                    //{
                    //    return null;
                    //}
                    if (!Accept<Access>())
                    {
                        return null;
                    }
                };
            }
            return this;
        }

        private void Skip()
        {
            Accept(new SkipUntil(ts, new TokenNode(ts, TokenTypes.Operator, ";"), true));
        }
    }
}
