using PygmentSharp.Core;
using PygmentSharp.Core.Lexing;
using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS
{
    /// <summary>
    /// A lexer of ActionScript3
    /// </summary>
    [Lexer("AS3", AlternateNames = "Actionscript3,ActionScript3,actionscript3,as3,as,Actionscript,ActionScript")]
    [LexerFileExtension("*.as")]
    public class ASLexer
    {
        public static string identifier = "[$a-zA-Z_][a-zA-Z0-9_]*";
        public static string typeidentifier = identifier + "(?:\\.<\\w+>)";

        protected override IDictionary<string, StateRule[]> GetStateRules()
        {
            var rules = new Dictionary<string, StateRule[]>();
            var builder = new StateRuleBuilder();

            rules["root"] = builder.NewRuleSet()
                .Add("\\s+", TokenTypes.Text)
                .ByGroups("(function\\s+)(" + identifier + ")(\\s*(\\()", "funcparams",
                new TokenGroupProcessor(TokenTypes.Keyword.Declaration),
                new TokenGroupProcessor(TokenTypes.Name.Function),
                new TokenGroupProcessor(TokenTypes.Operator))
                .Build();
        }
    }
}
