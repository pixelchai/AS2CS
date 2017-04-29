using AS2CS.Exceptions;
using AS2CS.Nodes;
using Newtonsoft.Json;
using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS
{
    [System.Diagnostics.DebuggerStepThrough]
    public abstract class Node
    {
        #region N_TOKENS
        [JsonIgnore]
        public TokenNode N_IDENTIFIER { get { return new TokenNode(this.ts, TokenTypes.Name); } }
        /// <summary>
        /// ;
        /// </summary>
        [JsonIgnore] public TokenNode N_SEMICOLON { get { return new TokenNode(this.ts, TokenTypes.Operator, ";"); } }
        /// <summary>
        /// ,
        /// </summary>
        [JsonIgnore] public TokenNode N_COMMA { get { return new TokenNode(this.ts, "", ","); } }
        /// <summary>
        /// {
        /// </summary>
        [JsonIgnore] public TokenNode N_LCURLY { get { return new TokenNode(this.ts, "", "{"); } }
        /// <summary>
        /// }
        /// </summary>
        [JsonIgnore] public TokenNode N_RCURLY { get { return new TokenNode(this.ts, "", "}"); } }
        /// <summary>
        /// (
        /// </summary>
        [JsonIgnore] public TokenNode N_LBRAC { get { return new TokenNode(this.ts, "", "("); } }
        /// <summary>
        /// )
        /// </summary>
        [JsonIgnore] public TokenNode N_RBRAC { get { return new TokenNode(this.ts, "", ")"); } }
        /// <summary>
        /// [
        /// </summary>
        [JsonIgnore] public TokenNode N_LSQUARE { get { return new TokenNode(this.ts, "", "["); } }
        /// <summary>
        /// ]
        /// </summary>
        [JsonIgnore] public TokenNode N_RSQUARE { get { return new TokenNode(this.ts, "", "]"); } }
        /// <summary>
        /// =
        /// </summary>
        [JsonIgnore] public TokenNode N_EQUALS { get { return new TokenNode(this.ts, "", "="); } }
        /// <summary>
        /// :
        /// </summary>
        [JsonIgnore] public TokenNode N_COLON { get { return new TokenNode(this.ts, "", ":"); } }
        /// <summary>
        /// *
        /// </summary>
        [JsonIgnore] public TokenNode N_ASTERISK { get { return new TokenNode(this.ts, "", "*"); } }
        /// <summary>
        /// use
        /// </summary>
        [JsonIgnore] public TokenNode N_USE { get { return new TokenNode(this.ts, "", "use"); } } //FIXME
        /// <summary>
        /// import
        /// </summary>
        [JsonIgnore] public TokenNode N_IMPORT { get { return new TokenNode(this.ts, TokenTypes.Keyword, "import"); } }
        /// <summary>
        /// true
        /// </summary>
        [JsonIgnore] public TokenNode N_TRUE { get { return new TokenNode(this.ts, TokenTypes.Keyword, "true"); } }
        /// <summary>
        /// false
        /// </summary>
        [JsonIgnore] public TokenNode N_FALSE { get { return new TokenNode(this.ts, TokenTypes.Keyword, "false"); } }
        /// <summary>
        /// null
        /// </summary>
        [JsonIgnore] public TokenNode N_NULL { get { return new TokenNode(this.ts, TokenTypes.Keyword, "null"); } }
        /// <summary>
        /// function
        /// </summary>
        [JsonIgnore] public TokenNode N_FUNCTION { get { return new TokenNode(this.ts, TokenTypes.Keyword, "function"); } }
        /// <summary>
        /// package
        /// </summary>
        [JsonIgnore] public TokenNode N_PACKAGE { get { return new TokenNode(this.ts, TokenTypes.Keyword, "package"); } }
        /// <summary>
        /// const
        /// </summary>
        [JsonIgnore] public TokenNode N_CONST { get { return new TokenNode(this.ts, TokenTypes.Keyword, "const"); } }
        /// <summary>
        /// void
        /// </summary>
        [JsonIgnore] public TokenNode N_VOID { get { return new TokenNode(this.ts, TokenTypes.Keyword, "void"); } }
        /// <summary>
        /// (namespace)
        /// </summary>
        [JsonIgnore] public TokenNode N_NAMESPACE { get { return new TokenNode(this.ts, TokenTypes.Name.Namespace); } }

        #endregion

        public List<Node> children = new List<Node>();
        [JsonIgnore] public TokenStream ts = null;
        [JsonIgnore] public int startIndex = 0;
        [JsonIgnore] public Node lastAccepted = null;
        [JsonIgnore] public Node parent = null;

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
