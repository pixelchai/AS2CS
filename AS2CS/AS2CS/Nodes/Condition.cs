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
            if (!SelectPart()) return null;
            SelectSecond();
            return this;
        }

        public bool SelectSecond()
        {
            if (Accept<Comparer>())
            {
                if (!SelectPart())
                {
                    this.UndoAccept();
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool SelectPart()
        {
            Accept(new TokenNode(ts, TokenTypes.Operator));//- or +

            if (!Accept(new TokenNode(ts, TokenTypes.Keyword.Constant)))
            {
                if (!Accept<Call>(false))
                {

                    if (!Accept<Access>() && !String.IsNullOrWhiteSpace(this.lastAccepted.GetValue()))
                    {
                        if (!Accept<Variable>(false))
                        {
                            if (!Accept<IncrDcr>(false))
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            //if (!Accept<Expression>())
            //{
            //    if (!Accept<Variable>(false))
            //    {
            //        if (!Accept<IncrDcr>(false))
            //        {
            //            if (!Accept<TokenNode>(TokenTypes.Keyword.Constant))
            //            {
            //                return false;
            //            }
            //        }
            //    }
            //}
            return true;
        }
    }
}
