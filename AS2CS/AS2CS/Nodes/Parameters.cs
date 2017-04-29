using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Parameters : Node
    {
        public Parameters(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            //adapted //CHECK

            //optional
            //if (Accept<Parameter>())
            //{
            //    while (Accept(new TokenNode(ts, "", ",")))
            //    {
            //        if (Accept(new TokenNode(ts, TokenTypes.Name)))
            //        {
            //            Accept<TypeRelation>();
            //        }
            //        if (!Accept<Parameter>())
            //        {
            //            break;
            //        }
            //    }
            //}

            if (Accept<Parameter>())
            {
                while (Accept(new TokenNode(ts, "", ",")))
                {
                    Accept<Parameter>();
                }
            }
            return this;
        }
    }
}
