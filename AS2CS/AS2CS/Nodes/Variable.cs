﻿using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Variable : Node
    {
        public bool IsInitialised = false;
        public bool needSemicolon = true;
        public Variable(TokenStream tokenStream) : base(tokenStream)
        {
        }
        public Variable(TokenStream tokenStream, bool needSemicolon = true) : base(tokenStream)
        {
            this.needSemicolon = needSemicolon;
        }

        public override Node Select()
        {
            while (true)
            {
                if(Accept(new TokenNode(ts, TokenTypes.Keyword/*.Declaration*/)))
                {
                    if (((TokenNode)lastAccepted).GetValue() == "function")
                    {
                        base.UndoAccept();
                        return null;
                    }
                }else
                {
                    break;
                }
            }
            if (!Expect(new TokenNode(ts, TokenTypes.Name))) return null;
            if (!Expect(new TokenNode(ts, TokenTypes.Punctuation,":"))) return null;
            if (!Expect(new TokenNode(ts, TokenTypes.Keyword.Type))) return null;
            if (Accept(new TokenNode(ts, TokenTypes.Operator, "=")))
            {
                IsInitialised = true;
                if (!Expect<Expression>()) return null;
            }
            if (needSemicolon)
                if (!Expect(new TokenNode(ts, TokenTypes.Operator, ";"))) return null;
            return this;
        }
    }
}
