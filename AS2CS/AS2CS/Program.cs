using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PygmentSharp.Core;
using PygmentSharp.Core.Lexing;
using PygmentSharp.Core.Tokens;
using System.Diagnostics;
using PygmentSharp.Core.Formatting;

namespace AS2CS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var highlighted = Pygmentize.File("input.as").WithLexer(new ASLexer());
            foreach (Token t in highlighted.GetTokens().ToList())
            {
                Console.WriteLine(t.ToString());
            }
            highlighted.WithFormatter(new HtmlFormatter(new HtmlFormatterOptions()
            {
                Full = true,
            })).ToFile("output.html");
            Process.Start("output.html");
        }
    }
}
