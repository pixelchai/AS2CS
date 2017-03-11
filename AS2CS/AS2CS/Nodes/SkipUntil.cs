using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class SkipUntil : Node
    {
        [JsonIgnore]
        internal Node until = null;
        public string value = null;

        public SkipUntil(TokenStream tokenStream, Node until) : base(tokenStream)
        {
            this.until = until;
        }

        public override Node Select()
        {
            while (true)
            {
                this.until.ts = base.ts;
                this.until.startIndex = base.ts.index;
                if (until.Select() == null)
                {
                    value += ts.getCur().Value + " ";
                    ts.increment();
                }
                else {
                    ts.increment(until.OffAmount()*-1);
                    break;
                }
            }
            return this;
        }
    }
}
