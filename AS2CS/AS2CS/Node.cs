using AS2CS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS
{
    public class Node
    {
        public enum VerificationMode
        {

        }

        public List<Node> children = new List<Node>();
        public TokenStream ts = null;
        public int startIndex = 0;

        public string typeName
        {
            get { return this.GetType().Name; }
        }

        public Node(TokenStream tokenStream)
        {
            this.ts = tokenStream;
            this.startIndex = this.ts.GetSave();
        }

        public virtual Node Select()
        {
            return null;
        }

        public int OffAmount()
        {
            return this.ts.GetSave() - startIndex;
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
           return Accept((Node)Activator.CreateInstance(typeof(T), new object[] { ts }));
        }

        public bool Accept(Node node)
        {
            if (node.Select() != null)
            {
                ts.increment(node.OffAmount());
                return true;
            }
            return false;
        }

        public bool Expect(Node node)
        {
            if (Accept(node))
            {
                return true;
            }
            throw new CompilerException(ts);
        }

        //public override string ToString()
        //{
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        //}
    }
}
