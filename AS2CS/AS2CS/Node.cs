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
        [JsonIgnore] public TokenNode N_NAMESPACE { get { return new TokenNode(this.ts, TokenTypes.Name.Namespace); } }
        [JsonIgnore] public TokenNode N_IDENTIFIER { get { return new TokenNode(this.ts, TokenTypes.Name); } }
        /// <summary>
        /// ;
        /// </summary>
        [JsonIgnore] public TokenNode N_SEMICOLON { get { return new TokenNode(this.ts, TokenTypes.Operator, ";"); } }
        /// <summary>
        /// .
        /// </summary>
        [JsonIgnore] public TokenNode N_DOT { get { return new TokenNode(this.ts, "", "."); } }
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
        /// ?
        /// </summary>
        [JsonIgnore] public TokenNode N_QUESTION { get { return new TokenNode(this.ts, "", "?"); } }
        /// <summary>
        /// *
        /// </summary>
        [JsonIgnore] public TokenNode N_ASTERISK { get { return new TokenNode(this.ts, "", "*"); } }

        [JsonIgnore] public TokenNode N_USE { get { return new TokenNode(this.ts, "", "use"); } } //FIXME
        [JsonIgnore] public TokenNode N_IMPORT { get { return new TokenNode(this.ts, TokenTypes.Keyword, "import"); } }
        [JsonIgnore] public TokenNode N_TRUE { get { return new TokenNode(this.ts, TokenTypes.Keyword, "true"); } }
        [JsonIgnore] public TokenNode N_FALSE { get { return new TokenNode(this.ts, TokenTypes.Keyword, "false"); } }
        [JsonIgnore] public TokenNode N_NULL { get { return new TokenNode(this.ts, TokenTypes.Keyword, "null"); } }
        [JsonIgnore] public TokenNode N_FUNCTION { get { return new TokenNode(this.ts, TokenTypes.Keyword, "function"); } }
        [JsonIgnore] public TokenNode N_PACKAGE { get { return new TokenNode(this.ts, TokenTypes.Keyword, "package"); } }
        [JsonIgnore] public TokenNode N_CONST { get { return new TokenNode(this.ts, TokenTypes.Keyword, "const"); } }
        [JsonIgnore] public TokenNode N_VAR { get { return new TokenNode(this.ts, TokenTypes.Keyword, "var"); } }
        [JsonIgnore] public TokenNode N_VOID { get { return new TokenNode(this.ts, TokenTypes.Keyword, "void"); } }
        [JsonIgnore] public TokenNode N_BREAK { get { return new TokenNode(this.ts, TokenTypes.Keyword, "break"); } }
        [JsonIgnore] public TokenNode N_RETURN { get { return new TokenNode(this.ts, TokenTypes.Keyword, "return"); } }
        [JsonIgnore] public TokenNode N_THROW { get { return new TokenNode(this.ts, TokenTypes.Keyword, "throw"); } }
        [JsonIgnore] public TokenNode N_SUPER { get { return new TokenNode(this.ts, TokenTypes.Keyword, "super"); } }
        [JsonIgnore] public TokenNode N_IF { get { return new TokenNode(this.ts, TokenTypes.Keyword, "if"); } }
        [JsonIgnore] public TokenNode N_ELSE { get { return new TokenNode(this.ts, TokenTypes.Keyword, "else"); } }
        [JsonIgnore] public TokenNode N_SWITCH { get { return new TokenNode(this.ts, TokenTypes.Keyword, "switch"); } }
        [JsonIgnore] public TokenNode N_WHILE { get { return new TokenNode(this.ts, TokenTypes.Keyword, "while"); } }
        [JsonIgnore] public TokenNode N_DO { get { return new TokenNode(this.ts, TokenTypes.Keyword, "do"); } }
        [JsonIgnore] public TokenNode N_FOR { get { return new TokenNode(this.ts, TokenTypes.Keyword, "for"); } }
        [JsonIgnore] public TokenNode N_EACH { get { return new TokenNode(this.ts, TokenTypes.Keyword, "each"); } }
        [JsonIgnore] public TokenNode N_IN { get { return new TokenNode(this.ts, TokenTypes.Keyword, "in"); } }
        [JsonIgnore] public TokenNode N_TRY { get { return new TokenNode(this.ts, TokenTypes.Keyword, "try"); } }
        [JsonIgnore] public TokenNode N_FINALLY { get { return new TokenNode(this.ts, TokenTypes.Keyword, "finally"); } }
        [JsonIgnore] public TokenNode N_CATCH { get { return new TokenNode(this.ts, TokenTypes.Keyword, "catch"); } }
        [JsonIgnore] public TokenNode N_CASE { get { return new TokenNode(this.ts, TokenTypes.Keyword, "case"); } }
        [JsonIgnore] public TokenNode N_DEFAULT { get { return new TokenNode(this.ts, TokenTypes.Keyword, "default"); } }
        [JsonIgnore] public TokenNode N_PUBLIC { get { return new TokenNode(this.ts, TokenTypes.Keyword, "public"); } }
        [JsonIgnore] public TokenNode N_PROTECTED { get { return new TokenNode(this.ts, TokenTypes.Keyword, "protected"); } }
        [JsonIgnore] public TokenNode N_PRIVATE { get { return new TokenNode(this.ts, TokenTypes.Keyword, "private"); } }
        [JsonIgnore] public TokenNode N_STATIC { get { return new TokenNode(this.ts, TokenTypes.Keyword, "static"); } }
        [JsonIgnore] public TokenNode N_ABSTRACT { get { return new TokenNode(this.ts, TokenTypes.Keyword, "abstract"); } }
        [JsonIgnore] public TokenNode N_FINAL { get { return new TokenNode(this.ts, TokenTypes.Keyword, "final"); } }
        [JsonIgnore] public TokenNode N_OVERRIDE { get { return new TokenNode(this.ts, TokenTypes.Keyword, "override"); } }
        [JsonIgnore] public TokenNode N_INTERNAL { get { return new TokenNode(this.ts, TokenTypes.Keyword, "internal"); } }
        [JsonIgnore] public TokenNode N_CONTINUE { get { return new TokenNode(this.ts, TokenTypes.Keyword, "continue"); } }
        [JsonIgnore] public TokenNode N_THIS { get { return new TokenNode(this.ts, TokenTypes.Keyword, "this"); } }
        [JsonIgnore] public TokenNode N_NEW { get { return new TokenNode(this.ts, TokenTypes.Keyword, "new"); } }
        [JsonIgnore] public TokenNode N_AS { get { return new TokenNode(this.ts, TokenTypes.Keyword, "as"); } }
        [JsonIgnore] public TokenNode N_IS { get { return new TokenNode(this.ts, TokenTypes.Keyword, "is"); } }
        [JsonIgnore] public TokenNode N_DELETE { get { return new TokenNode(this.ts, TokenTypes.Keyword, "delete"); } }

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
