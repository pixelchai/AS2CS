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
            ///*h: 
            ///paranthesizedExpr,
            ///(statement), 
            ///statementInSwitch, 
            ///catches, 
            ///(block), 
            ///namedFunctionExpr
            ///*
            
            throw new NotImplementedException();
        }
    }
}
