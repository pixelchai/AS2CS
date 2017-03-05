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

        public string typeName
        {
            get { return this.GetType().Name; }
        }

        public virtual Node Select(TokenStream ts)
        {
            return null;
        }

        public Node SelectSafe(TokenStream ts)
        {
            int save = ts.GetSave();
            Node ret;
            try
            {
                ret = Select(ts);
            }
            catch
            {
                throw;
            }
            finally
            {
                ts.SetSave(save);
            }
            return ret;
        }
        //public override string ToString()
        //{
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        //}
    }
}
