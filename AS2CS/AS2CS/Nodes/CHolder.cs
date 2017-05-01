using Newtonsoft.Json;
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
    public class CHolder : Node
    {
        //public System.Type type { get; private set; } = null;
        [JsonIgnore]
        public List<Node> Nodes = new List<Node>();
        public CHolder(TokenStream tokenStream) : base(tokenStream)
        {
        }

        public CHolder(TokenStream tokenStream, params Node[] nodes) : base(tokenStream)
        {
            Nodes.AddRange(nodes);
        }

        public override Node Select()
        {
            Node first = Nodes.First();
            first.ts = this.ts;//in case
            if (!Accept(first)) return null;
            Nodes.RemoveAt(0);//rem first

            foreach (Node n in Nodes)
            {
                n.ts = this.ts;//in case
                Expect(n);
            }
            return this;
        }
    }
}
