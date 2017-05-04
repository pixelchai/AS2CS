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
        public List<Node> Nodes = new List<Node>();
        public Holder(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public Holder(TokenStream tokenStream, params Node[] nodes) : base(tokenStream)
        {
            Nodes.AddRange(nodes);
        }

        public override Node Select()
        {
            foreach (Node n in Nodes)
            {
                n.ts = this.ts;//in case
                Expect(n);
            }
            return this;
        }
    }
}
