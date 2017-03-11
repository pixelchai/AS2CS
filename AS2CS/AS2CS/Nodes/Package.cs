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
            while (Accept(new TokenNode(ts, TokenTypes.Keyword.Declaration))) { }//public static ...

            base.ts.SetSave(ts.tokens.Count - 2);
            return this;
        }
    }
}
