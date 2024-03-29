﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class ParenthesizedExpr : Node
    {
        public ParenthesizedExpr(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(N_LBRAC)) return null;
            if (!Accept<ExprOrObjectLiteral>()) return null;
            if (!Accept(N_RBRAC)) return null;
            return this;
        }
    }
}
