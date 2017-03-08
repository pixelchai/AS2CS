using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS
{
    public class Node
    {
        public List<Node> children = new List<Node>();
        public TokenStream ts = null;

        public string typeName
        {
            get { return this.GetType().Name; }
        }

        public Node(TokenStream tokenStream)
        {
            this.ts = tokenStream;
        }

        public virtual Node Select()
        {
            return null;
        }

        //public Node SelectSafe(TokenStream ts)
        //{
        //    int save = ts.GetSave();
        //    Node ret;
        //    try
        //    {
        //        ret = Select(ts);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        ts.SetSave(save);
        //    }
        //    return ret;
        //}

        public bool Accept<T>() where T : Node
        {
           return Accept(Tctivator.CreateInstance(typeof(T), new object[] { weight });
        }

        public bool Accept(Node node)
        {

        }

        //public override string ToString()
        //{
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        //}
    }
}
