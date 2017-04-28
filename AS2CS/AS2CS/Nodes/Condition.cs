using PygmentSharp.Core.Tokens;
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
                    Console.WriteLine("NO SECOND PART!");
                    this.UndoAccept();
                    return false;
                }
                Console.WriteLine("SELECTED SECOND PART!!");
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool SelectPart()
        {
            Accept<OperationOperator>();
            foreach (TokenType type in Expression.types)
            {
                if (Accept(new TokenNode(ts, type)))
                {
                    return true;
                }
            }

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
