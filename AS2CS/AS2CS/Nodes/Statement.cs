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
                                                //h labelablestatement
                                                return null;
                                            }
                                            else
                                            {
                                                //h
                                            }
                                        }
                                        else
                                        {
                                            //h
                                        }
                                    }
                                    else
                                    {
                                        //h
                                    }
                                }
                                else
                                {
                                    //h
                                }
                            }
                            else
                            {
                                //h
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
                        //h labelableStatement
                    }
                }
                else
                {
                    Expect(N_SEMICOLON);
                }
            }
        }
    }
}
