using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Statement : Node
    {
        public Statement(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(N_SEMICOLON))
            {
                if (!Accept<CommaExpr>())
                {
                    if (!Accept(N_IDENTIFIER))
                    {
                        if (!Accept<VariableDeclaration>())
                        {
                            if (!Accept(N_BREAK))
                            {
                                if (!Accept(N_CONTINUE))
                                {
                                    if (!Accept(N_RETURN))
                                    {
                                        if (!Accept(N_THROW))
                                        {
                                            if (!Accept(N_SUPER))
                                            {
                                                if(!Accept<LabelableStatement>())return null;
                                            }
                                            else
                                            {
                                                Expect(N_LBRAC);
                                                Expect<Arguments>();
                                                Expect(N_RBRAC);
                                            }
                                        }
                                        else
                                        {
                                            Expect<CommaExpr>();
                                            Expect(N_SEMICOLON);
                                        }
                                    }
                                    else
                                    {
                                        Expect<ExprOrObjectLiteral>();
                                        Expect(N_SEMICOLON);
                                    }
                                }
                                else
                                {
                                    Accept(N_IDENTIFIER);//opt
                                    Expect(N_SEMICOLON);
                                }
                            }
                            else
                            {
                                Accept(N_IDENTIFIER);//opt
                                Expect(N_SEMICOLON);
                            }
                        }
                        else
                        {
                            Expect(N_SEMICOLON);
                        }
                    }
                    else
                    {
                        Expect(N_COLON);
                        Expect<LabelableStatement>();
                    }
                }
                else
                {
                    Expect(N_SEMICOLON);
                }
            }
            return this;
        }
    }
}
