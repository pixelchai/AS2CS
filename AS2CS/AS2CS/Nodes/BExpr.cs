using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    /// <summary>
    /// added - bridge to Expr. Use this.
    /// </summary>
    public class BExpr : Node
    {
        public BExpr(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept<Expr>()) return null; //non overflowing Expr
            //check for overflowing things in non-overflowing way: (I.e, do not start with Expr)

            while (true)
            {
                #region comment
                //if (!Accept(N_LSQUARE))//indexor
                //{
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
                //                    continue;
                //                }
                //                else
                //                {
                //                    base.UndoAccept();//undo infix
                //                    if (Accept<PostfixOperator>())
                //                    {
                //                        continue;
                //                    }//else fall to next if
                //                }
                //            }
                //            #endregion
                //            if (!Accept(N_LBRAC))
                //            {
                //                if (!Accept(N_QUESTION))
                //                {
                //                    break;
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
                //else
                //{
                //    Expect<CommaExpr>();
                //    Expect(N_RSQUARE);
                //    //Expect(new Holder(ts,
                //    //    new CommaExpr(ts),
                //    //    RSQ
                //    //    ));
                //}
                #endregion

                if (!Accept(new CHolder(ts,
                        N_LSQUARE,
                        new CommaExpr(ts),
                        N_RSQUARE)))//indexor
                {
                    if (!Accept(new CHolder(ts,
                        N_AS,
                        new Type(ts)
                        )))
                    {
                        if (!Accept(new CHolder(ts,
                            N_IS,
                            new BExpr(ts)
                        )))
                        {
                            if (!base.Accept<InfixOrPostfixOperator>())
                            {
                                #region fancy
                                ////ad fancy
                                //if (base.Accept<InfixOperator>())
                                //{
                                //    if (Accept<Expr>())
                                //    {
                                //        continue;
                                //    }
                                //    else
                                //    {
                                //        base.UndoAccept();//undo infix
                                //        if (Accept<PostfixOperator>())
                                //        {
                                //            continue;
                                //        }//else fall to next if
                                //    }
                                //}
                                #endregion
                                if (!Accept(new CHolder(ts,
                                    N_LBRAC,
                                    new Arguments(ts),
                                    N_RBRAC
                            )))
                                {
                                    if (!Accept(new CHolder(ts,
                                        N_QUESTION,
                                        new ExprOrObjectLiteral(ts),
                                        N_COLON,
                                        new ExprOrObjectLiteral(ts)
                            )))
                                    {
                                        break;
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
