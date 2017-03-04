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
    public class ASLexer : RegexLexer
    {
        public static string identifier = @"[$a-zA-Z_][a-zA-Z0-9_]*";
        public static string typeidentifier = identifier + @"(?:\.<\w+>)?";
        public static string ws = @"(?:\s|//.*?\n|/[*].*?[*]/)+";

        protected override IDictionary<string, StateRule[]> GetStateRules()
        {
            var rules = new Dictionary<string, StateRule[]>();
            var builder = new StateRuleBuilder();

            rules["root"] = builder.NewRuleSet()
                .Add(@"[^\S\n]+", TokenTypes.Text)
                .ByGroups(@"(function\s+)(" + identifier + @")(\s*)(\()"/*, "funcparams"*/,
                    new TokenGroupProcessor(TokenTypes.Keyword.Declaration),
                    new TokenGroupProcessor(TokenTypes.Name.Function),
                    new TokenGroupProcessor(TokenTypes.Text),//added
                    new TokenGroupProcessor(TokenTypes.Operator))
                .ByGroups("(var|const)(\\s+)("+identifier+")(\\s*)(:)(\\s*)("+typeidentifier+")",
                    new TokenGroupProcessor(TokenTypes.Keyword.Declaration),
                    new TokenGroupProcessor(TokenTypes.Text),
                    new TokenGroupProcessor(TokenTypes.Name),
                    new TokenGroupProcessor(TokenTypes.Text),
                    new TokenGroupProcessor(TokenTypes.Punctuation),
                    new TokenGroupProcessor(TokenTypes.Text),
                    new TokenGroupProcessor(TokenTypes.Keyword.Type))
                .ByGroups(@"(\s*)(\.\.\.)?("+identifier+@")(\s*)(:)(\s*)("+typeidentifier+@"|\*)(\s*)",
                    new TokenGroupProcessor(TokenTypes.Text),
                    new TokenGroupProcessor(TokenTypes.Text),
                    new TokenGroupProcessor(TokenTypes.Name),
                    new TokenGroupProcessor(TokenTypes.Text),
                    new TokenGroupProcessor(TokenTypes.Punctuation),
                    new TokenGroupProcessor(TokenTypes.Text),
                    new TokenGroupProcessor(TokenTypes.Keyword.Type),
                    new TokenGroupProcessor(TokenTypes.Text))//added
                    .ByGroups(@"(\s*)(\.\.\.)?("+identifier+@")(\s*)(:)(\s*)("+typeidentifier+@"|\*)(\s*)((=)(\s*)([^(),]+)(\s*))",
                    new TokenGroupProcessor(TokenTypes.Text),
                    new TokenGroupProcessor(TokenTypes.Text),
                    new TokenGroupProcessor(TokenTypes.Name),
                    new TokenGroupProcessor(TokenTypes.Text),
                    new TokenGroupProcessor(TokenTypes.Punctuation),
                    new TokenGroupProcessor(TokenTypes.Text),
                    new TokenGroupProcessor(TokenTypes.Keyword.Type),
                    new TokenGroupProcessor(TokenTypes.Text),
                    new TokenGroupProcessor(TokenTypes.Operator),
                    new TokenGroupProcessor(TokenTypes.Text),
                    new LexerGroupProcessor(this),
                    new TokenGroupProcessor(TokenTypes.Text))//added
                 .ByGroups(@"(import|package)(\s+)((?:"+identifier+ @"|\.)+)(\s*)",
                    new TokenGroupProcessor(TokenTypes.Keyword),
                    new TokenGroupProcessor(TokenTypes.Text),
                    new TokenGroupProcessor(TokenTypes.Name.Namespace),
                    new TokenGroupProcessor(TokenTypes.Text))
                .ByGroups(@"(new)(\s+)("+typeidentifier+ @")(\s*)(\()",
                    new TokenGroupProcessor(TokenTypes.Keyword),
                    new TokenGroupProcessor(TokenTypes.Text),
                    new TokenGroupProcessor(TokenTypes.Keyword.Type),
                    new TokenGroupProcessor(TokenTypes.Text),
                    new TokenGroupProcessor(TokenTypes.Operator))
                 .ByGroups(@"(\.)("+identifier+")",
                    new TokenGroupProcessor(TokenTypes.Operator),
                    new TokenGroupProcessor(TokenTypes.Name.Attribute)) //added
                .Add(@"""(\\\\|\\""|[^""])*""", TokenTypes.String.Double)
                .Add(@"'(\\\\|\\'|[^'])*'", TokenTypes.String.Single)
                .Add(@"\/\/.*?\n", TokenTypes.Comment.Single)
                .Add(@"\/\*(.|\s)*?\*\/", TokenTypes.Comment.Multiline)
                .Add(@"/(\\\\|\\/|[^\n])*/[gisx]*", TokenTypes.String.Regex)
                .Add(@"[~\^\*!%&<>\|+=:;,/?\\{}\[\]().-]", TokenTypes.Operator)
                .Add(@"(case|default|for|each|in|while|do|break|return|continue|if|else|'
             r'throw|try|catch|with|new|typeof|arguments|instanceof|this|'
             r'switch|import|include|as|is)\b", TokenTypes.Keyword)
                .Add(@"(class|public|final|internal|native|override|private|protected|'
             r'static|import|extends|implements|interface|intrinsic|return|super|'
             r'dynamic|function|const|get|namespace|package|set)\b", TokenTypes.Keyword.Declaration)
                .Add(@"(true|false|null|NaN|Infinity|-Infinity|undefined|void)\b", TokenTypes.Keyword.Constant)
                .Add(@"(decodeURI|decodeURIComponent|encodeURI|escape|eval|isFinite|isNaN|
                      isXMLName|clearInterval|fscommand|getTimer|getURL|getVersion|
                      isFinite|parseFloat|parseInt|setInterval|trace|updateAfterEvent|unescape)\b", TokenTypes.Name.Function)
                .ByGroups(@"(\@)("+identifier+")",
                    new TokenGroupProcessor(TokenTypes.Punctuation),
                    new TokenGroupProcessor(TokenTypes.Name))
                .Add(identifier,TokenTypes.Name)
                .Add(@"[0-9][0-9]*\.[0-9]+([eE][0-9]+)?[fd]?",TokenTypes.Number.Float)
                .Add(@"0x[0-9a-fA-F]+", TokenTypes.Number.Hex)
                .Add(@"[0-9]+",TokenTypes.Number.Integer)
                .Build();

            rules["type"] = builder.NewRuleSet()
                .ByGroups(@"(\s*)(:)(\s*)("+typeidentifier+ @"|\*)",
                "#pop:2",
                new TokenGroupProcessor(TokenTypes.Text),
                new TokenGroupProcessor(TokenTypes.Operator),
                new TokenGroupProcessor(TokenTypes.Text),
                new TokenGroupProcessor(TokenTypes.Keyword.Type))
                .Add(@"\s*",TokenTypes.Text,"#pop:2")
            .Build();

            return rules;
        }
    }
}
