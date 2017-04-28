using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Statement : Node
    {
        public bool NeedSemicolon = true;
        public Statement(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public Statement(TokenStream tokenStream, bool needSemicolon) : base(tokenStream)
        {
            this.NeedSemicolon = needSemicolon;
        }

        public override Node Select()
        {
            if (!Accept<Return>())
            {
                if (!Accept<Conditional>())
                {
                    if (!Accept<Loop>())
                    {
                        if (!Accept<Call>(NeedSemicolon))
                        {
                            if (!Accept<Variable>())
                            {
                                if (!Accept(new Bracket<Statement>(ts)))
                                {
                                    if (!Accept<IncrDcr>())
                                    {
                                        //todo
                                        //throw new Exceptions.CompilerException(ts);
                                        return null;
                                        // Skip();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return this;
        }

        private void Skip()
        {
            Accept(new SkipUntil(ts, new TokenNode(ts, TokenTypes.Operator, ";"), true));
        }
    }
}
