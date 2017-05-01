using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Expr : Node
    {
        //public bool OverFlowers { get; private set; } = true;
        public Expr(TokenStream tokenStream) : base(tokenStream)
        {
        }

        //public Expr(TokenStream tokenStream,bool overFlowers) : base(tokenStream)
        //{
        //    OverFlowers = overFlowers;
        //}

        public override Node Select()
        {
            if (!Accept(new TokenNode(ts, TokenTypes.Number)))//PODO
            {
                //r float //PODO
                if (!Accept(new TokenNode(ts, TokenTypes.String)))//PODO
                {
                    //r regex//PODO
                    if (!Accept(N_TRUE)
                        && !Accept(N_FALSE)
                        && !Accept(N_NULL))
                    {
                        if (!Accept(new TokenNode(ts, TokenTypes.Keyword.Constant)))
                        {
                            if (!Accept<ArrayLiteral>())
                            {
                                if (!Accept<Lvalue>())//STACKOVERFLOW
                                {
                                    if (!Accept<AnonFunctionExpr>())
                                    {
                                        if (!Accept(N_THIS))
                                        {
                                            if (!Accept<ParenthesizedExpr>())
                                            {
                                                if (!Accept(N_NEW))
                                                {

                                                    if (!Accept(N_DELETE))
                                                    {
                                                        //ad
                                                        if (!Accept<PrefixOperator>())
                                                        {
                                                            return null;
                                                        }
                                                        else
                                                        {
                                                            Expect<BExpr>();
                                                        }

                                                        //if (!Accept<Expr>())
                                                        //{
                                                        //    if (!Accept<PrefixOperator>())
                                                        //    {
                                                        //        return null;
                                                        //    }
                                                        //    else
                                                        //    {
                                                        //        Expect<Expr>();
                                                        //    }
                                                        //}
                                                        //else
                                                        //{
                                                        //    /**
                                                        //      | expr "as" type  
                                                        //      | expr "is" expr  
                                                        //      | expr POSTFIX_OPERATOR  
                                                        //      | expr INFIX_OPERATOR expr  
                                                        //      | expr "(" arguments ")"  
                                                        //      | expr "?" exprOrObjectLiteral ":" exprOrObjectLiteral;
                                                        //    */
                                                        //    //CFGad proposition: //OVERRULED for now
                                                        //    /**
                                                        //        expr "[" expr "]" //OVERRULED! - In lvalue
                                                        //        + maybe
                                                        //        expr "{" expr "}"
                                                        //    */
                                                        //    if (!Accept(N_AS))
                                                        //    {
                                                        //        if (!Accept(N_IS))
                                                        //        {
                                                        //            #region fancy
                                                        //            //ad fancy
                                                        //            if (Accept<InfixOperator>())
                                                        //            {
                                                        //                if (Accept<Expr>())
                                                        //                {
                                                        //                    return this;
                                                        //                }
                                                        //                else
                                                        //                {
                                                        //                    base.UndoAccept();//undo infix
                                                        //                    if (Accept<PostfixOperator>())
                                                        //                    {
                                                        //                        return this;
                                                        //                    }//else fall to next if
                                                        //                }
                                                        //            }
                                                        //            #endregion
                                                        //            if (!Accept(N_LBRAC))
                                                        //            {
                                                        //                if (!Accept(N_QUESTION))
                                                        //                {
                                                        //                    return null;
                                                        //                }
                                                        //                else
                                                        //                {
                                                        //                    Expect<ExprOrObjectLiteral>();
                                                        //                    Expect(N_COLON);
                                                        //                    Expect<ExprOrObjectLiteral>();
                                                        //                }
                                                        //            }
                                                        //            else
                                                        //            {
                                                        //                Expect<Arguments>();
                                                        //                Expect(N_RBRAC);
                                                        //            }
                                                        //        }
                                                        //        else
                                                        //        {
                                                        //            Expect<Expr>();
                                                        //        }
                                                        //    }
                                                        //    else
                                                        //    {
                                                        //        Expect<Type>();
                                                        //    }
                                                        //}
                                                    }
                                                    else
                                                    {
                                                        Expect<BExpr>();
                                                    }
                                                }
                                                else
                                                {
                                                    Expect<Type>();
                                                    if (Accept(N_LBRAC))//opt
                                                    {
                                                        Expect<Arguments>();
                                                        Expect(N_RBRAC);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return this;
        }
    }
}
