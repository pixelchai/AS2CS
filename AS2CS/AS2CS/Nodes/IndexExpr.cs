using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    /// <summary>
    /// added
    /// </summary>
    public class IndexExpr : Node
    {
        public IndexExpr(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            throw new NotImplementedException();
        }
    }
}
