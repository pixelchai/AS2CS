using AS2CS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class LabelableStatement : Node
    {
        protected LabelableStatement(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(N_IF))
            {
                if (!Accept(N_SWITCH))
                {
                    if (!Accept(N_WHILE))
                    {
                        if (!Accept(N_DO))
                        {
                            if (!Accept(N_FOR))
                            {
                                if (!Accept(N_TRY))
                                {
                                    if (!Accept<NamedFunctionExpr>())
                                    {
                                        if (!Accept<Block>())
                                        {
                                            return null;
                                        }
                                    }
                                }
                                else
                                {
                                    #region fancy TRY stuff
                                    //ad
                                    Expect<Block>();
                                    bool isCatches = Accept<Catches>();
                                    if (Accept(N_FINALLY))
                                    {
                                        Expect<Block>();
                                    }
                                    else
                                    {
                                        if (!isCatches)
                                        {
                                            throw new CompilerException(ts);
                                        }
                                    }
                                    #endregion
                                }
                            }
                            else
                            {
                                #region fancy FOR stuff
                                //ad
                                bool isEach = Accept(N_EACH);
                                Expect(N_LBRAC);
                                if (Accept(N_VAR))
                                {
                                    ///* "for" "(" "var" identifierDeclaration {"," identifierDeclaration} ";"
                                    ///         [commaExpr] ";" [commaExpr] ")" statement
                                    // or
                                    ///* "for" ["each"] "(" "var" IDENTIFIER [typeRelation] "in" expr ")" statement  

                                    if (!isEach)
                                    {
                                        if (Accept<IdentifierDeclaration>())
                                        {
                                            while (Accept(N_COMMA))
                                            {
                                                Expect<IdentifierDeclaration>();
                                            }
                                            Expect(N_SEMICOLON);
                                            Accept<CommaExpr>();//opt
                                            Expect(N_SEMICOLON);
                                            Accept<CommaExpr>();//opt
                                            Expect(N_RBRAC);
                                            Expect<Statement>();
                                            return this;
                                        }//else fall to next if
                                    }

                                    if (Expect(N_IDENTIFIER))
                                    {
                                        Accept<TypeRelation>();//opt
                                        Expect(N_IN);
                                        Expect<Expr>();
                                        Expect(N_RBRAC);
                                        Expect<Statement>();
                                    }
                                    else
                                    {
                                        throw new CompilerException(ts);
                                    }
                                }
                                else
                                {
                                    if (Accept(N_IDENTIFIER))
                                    {
                                        //"for"["each"] "(" IDENTIFIER "in" expr ")" statement
                                        Expect(N_IN);
                                        Expect<Expr>();
                                        Expect(N_RBRAC);
                                        Expect<Statement>();
                                    }
                                    else if (!isEach)
                                    {
                                        //"for" "(" [commaExpr] ";" [commaExpr] ";" [commaExpr] ")" statement
                                        Accept<CommaExpr>();//opt
                                        Expect(N_SEMICOLON);
                                        Accept<CommaExpr>();//opt
                                        Expect(N_SEMICOLON);
                                        Accept<CommaExpr>();//opt
                                        Expect(N_RBRAC);
                                        Expect<Statement>();
                                    }
                                    else
                                    {
                                        throw new CompilerException(ts);
                                    }
                                }
                                #endregion
                            }
                        }
                        else
                        {
                            Expect<Statement>();
                            Expect(N_WHILE);
                            Expect<ParenthesizedExpr>();
                            Expect(N_SEMICOLON);
                        }
                    }
                    else
                    {
                        Expect<ParenthesizedExpr>();
                        Expect<Statement>();
                    }
                }
                else
                {
                    Expect<ParenthesizedExpr>();
                    Expect(N_LCURLY);
                    while (Accept<StatementInSwitch>()) { }
                    Expect(N_RCURLY);
                }
            }
            else
            {
                Expect<ParenthesizedExpr>();
                Expect<Statement>();

                //ad
                if (Accept(N_ELSE))
                {
                    Expect<Statement>();
                }
            }

            return this;
        }
    }
}
