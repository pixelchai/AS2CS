using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class SkipBrac : Node
    {
        public string LBRAC = "(";
        public string RBRAC = ")";

        public bool accept = false;
        private string value = "";

        public override string GetValue()
        {
            return value;
        }

        public SkipBrac(TokenStream tokenStream, string lbrac = "(", string rbrac = ")", bool accept = false) : base(tokenStream)
        {
            this.LBRAC = lbrac;
            this.RBRAC = rbrac;
            this.accept = accept;
        }

        public override Node Select()
        {
            while (true)
            {
                this.until.ts = base.ts;
                this.until.startIndex = base.ts.index;
                if (until.Select() == null)
                {
                    this.value += ts.getCur().Value + " ";
                    children.Add(new TokenNode(ts.getCur()));
                    ts.increment();
                }
                else {
                    //children.RemoveAt(children.Count - 1);
                    children.Remove(until);
                    ts.increment(until.OffAmount() * -1);
                    break;
                }
            }
            return this;
        }
    }
}
