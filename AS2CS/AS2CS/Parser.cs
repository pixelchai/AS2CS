//https://en.wikipedia.org/wiki/Recursive_descent_parser

using AS2CS.Nodes;
using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS
{
    public class Parser
    {
        public TokenStream stream = null;

        public Parser() { }
        public Parser(TokenStream ts)
        {
            this.stream = ts;
        }

        public ASFile Parse()
        {
            //ASFile file = new ASFile();
            return null;//TODO
        }
    }
}