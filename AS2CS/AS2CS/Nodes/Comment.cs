using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class Comment : Node
    {
        /// <summary>
        /// ad
        /// </summary>
        /// <param name="tokenStream"></param>
        public Comment(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public override Node Select()
        {
            if (!Accept(N_COMMENT)) return null;
            return this;
        }
    }
}
