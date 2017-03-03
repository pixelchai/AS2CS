using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PygmentSharp.Core;
using PygmentSharp.Core.Lexing;
using PygmentSharp.Core.Tokens;

namespace AS2CS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Token> tokens = Pygmentize.File("input.as").WithLexer(new ASLexer()).GetTokens().ToList();
            foreach (Token t in tokens)
            {
                Console.WriteLine(t.ToString());
            }
        }
    }
}
