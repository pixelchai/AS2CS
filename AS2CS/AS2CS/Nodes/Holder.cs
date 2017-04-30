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
    public class Holder : Node
    {
        //public System.Type type { get; private set; } = null;
        public Holder(TokenStream tokenStream) : base(tokenStream)
        {
        }

        //public Holder(TokenStream tokenStream, System.Type t) : base(tokenStream)
        //{
        //    this.type = t;
        //}

        public override Node Select()
        {
            throw new NotImplementedException();
        }
    }
}
