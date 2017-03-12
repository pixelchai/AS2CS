﻿using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Condition : Node
    {
        public Condition(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<Call>(false))
            {
                if (!Accept<Variable>(false))
                {
                    if (!Accept<IncrDcr>(false))
                    {
                        if (!Accept<TokenNode>(TokenTypes.Keyword.Constant))
                        {
                            if (!Accept<Access>())
                            {
                                return null;
                            }
                            else
                            {
                                if (!Accept<TokenNode>(TokenTypes.Operator)) return null;
                                while (Accept<TokenNode>(TokenTypes.Operator)) { }
                                if (!Accept<Access>()) return null;
                            }
                        }
                    }
                }
            }
            return this;
        }
    }
}
