using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Package : Node
    {
        public Package(TokenStream ts) : base(ts) { }

        public override Node Select()
        {
            while (base.Accept<Import>()) { }//imports
            while (Accept(new TokenNode(ts, TokenTypes.Keyword.Declaration))) { }//public static ... class
            if (!Expect(new TokenNode(ts, TokenTypes.Name))) return null;//classname
            if (!Accept(new SkipUntil(ts, new TokenNode(ts, TokenTypes.Operator, "{")))) return null;//skip until {
            if (!Expect(new TokenNode(ts, TokenTypes.Operator,"{"))) return null;
            Accept<Class>();
            //if (!Expect(new TokenNode(ts, TokenTypes.Operator,"}"))) return null;

            base.ts.SetSave(ts.tokens.Count - 2);
            return this;
        }
    }
}
