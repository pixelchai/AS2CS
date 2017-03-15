using AS2CS.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS
{
    public abstract class Node
    {
        public List<Node> children = new List<Node>();
        [JsonIgnore]
        public TokenStream ts = null;
        [JsonIgnore]
        public int startIndex = 0;
        [JsonIgnore]
        public Node lastAccepted = null;
        [JsonIgnore]
        public Node parent = null;

        public string typeName
        {
            get { return this.GetType().Name; }
        }

        private string value = "";

        public string Value { get { return GetValue(); } }

        public virtual string GetValue()
        {
            return value;
        }

        protected Node(TokenStream tokenStream)
        {
            this.ts = tokenStream;
            try
            {
                this.startIndex = this.ts.GetSave();
            }
            catch { }
        }

        public abstract Node Select();

        public Node mostParent()
        {
            Node cur = this;
            while (cur.parent != null)
            {
                cur = cur.parent;
            }
            return cur;
        }

        public int OffAmount()
        {
            return this.ts.GetSave() - startIndex;
        }

        public bool Accept<T>(params object[] addArgs) where T : Node
        {
            List<object> args = new List<object>();
            args.Add(ts);
            if (addArgs.Length > 0)
            {
                args.AddRange(addArgs);
            }
           return Accept((Node)Activator.CreateInstance(typeof(T), args.ToArray()));
        }

        public bool Expect<T>(params object[] addArgs) where T : Node
        {
            List<object> args = new List<object>();
            args.Add(ts);
            args.AddRange(addArgs);
            return Expect((Node)Activator.CreateInstance(typeof(T), args.ToArray()));
        }

        public bool Accept(Node node)
        {
            try {
                Debug.Indent();
                node.parent = this;
                if ((lastAccepted = node.Select()) != null)
                {
                    if (Utils.DEBUG_PARSING)
                    {
                        Debug.WriteLine(this.typeName + " node accepted: " + node.typeName+" -- "+ts.look(-1).Value);
                    }
                    children.Add(node);
                    this.value += node.GetValue()+" ";
                    //ts.increment(node.OffAmount());
                    return true;
                }
                node.ts.SetSave(node.startIndex);
                return false;
            }
            finally
            {
                Debug.UnIndent();
            }
        }

        //public string GetValue()
        //{
        //    if (this is IBaseNode)
        //    {
        //        return ((IBaseNode)this).Value;
        //    }
        //    else
        //    {
        //        return this.selected;
        //    }
        //}

        public void UndoAccept()
        {
            if (Utils.DEBUG_PARSING)
            {
                Debug.WriteLine(this.typeName + " node undo-accepted: " + lastAccepted.typeName + "!");
            }
            this.ts.increment(this.lastAccepted.OffAmount() * -1);
        }

        public bool Expect(Node node)
        {
            if (Accept(node))
            {
                return true;
            }
            throw new CompilerException(ts);
        }

        public string ToJSON()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, new Newtonsoft.Json.JsonSerializerSettings()
            {
            });
        }
    }
}
