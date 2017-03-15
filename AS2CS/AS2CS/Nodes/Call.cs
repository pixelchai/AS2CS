using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Call : Node
    {
        public bool needSemicolon = true;
        public bool IsIndexerCall { get; private set; } = false;
        public Call(TokenStream tokenStream) : base(tokenStream)
        {
        }
        public Call(TokenStream tokenStream, bool needSemicolon = true) : base(tokenStream)
        {
            this.needSemicolon = needSemicolon;
        }

        public override Node Select()
        {
            if (!Accept<Access>()) return null;
            if (!Accept(new TokenNode(ts, TokenTypes.Operator, "(")))
            {
                if (!Accept(new TokenNode(ts, TokenTypes.Operator, "["))) { return null; }
                else
                {
                    IsIndexerCall = true;
                }
            }
            Console.WriteLine("WOOOOOOOOOOOOOOOOOOOOOOOOOOO");
            Accept<ParamsSend>();
            Console.WriteLine("LOOOOOOOOOOOOOOOOOOOOOOOOOOO");
            if (!IsIndexerCall)
            {
                if (!Accept(new TokenNode(ts, TokenTypes.Operator, ")"))) return null;
            }
            else
            {
                if (!Accept(new TokenNode(ts, TokenTypes.Operator, "]"))) return null;
            }
            if (needSemicolon)
                if (!Expect(new TokenNode(ts, TokenTypes.Operator, ";"))) return null;
            return this;
        }
    }
}
