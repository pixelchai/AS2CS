using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Constructor : Node
    {
        public Constructor(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            while (true)
            {
                if (Accept(new TokenNode(ts, TokenTypes.Keyword.Declaration)))
                {
                    if (((TokenNode)lastAccepted).GetValue() == "var" || ((TokenNode)lastAccepted).GetValue() == "const")
                    {
                        base.UndoAccept();
                        return null;
                    }
                }
                else
                {
                    break;
                }
            }//public static ... function 
            if (!Expect(new TokenNode(ts, TokenTypes.Name))) return null;
            if (!Expect(new TokenNode(ts, TokenTypes.Operator, "("))) return null;
            if (!Accept<ParamsRecv>()) return null;
            if (!Expect(new TokenNode(ts, TokenTypes.Operator, ")"))) return null;
            if (!Accept(new TokenNode(ts, TokenTypes.Operator, "{"))) return null;
            Accept<MethodBody>();
            if (!Accept(new TokenNode(ts, TokenTypes.Operator, "}"))) return null;
            return this;
        }
    }
}
