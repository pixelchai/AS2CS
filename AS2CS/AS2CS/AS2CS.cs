using AS2CS.Exceptions;
using AS2CS.Nodes;
using FastColoredTextBoxNS;
using Newtonsoft.Json.Linq;
using PygmentSharp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AS2CS
{
    public partial class AS2CS : Form
    {
        public AS2CS()
        {
            InitializeComponent();
        }

        private void fastColoredTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.timer1.Stop();
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            Compile();
            this.timer1.Stop();
        }

        private void Compile()
        {
            using (StreamWriter sw = new StreamWriter("temp.as"))
            {
                sw.WriteLine(fastColoredTextBox1.Text);
            }
            var lexed = Pygmentize.File("temp.as").WithLexer(new ASLexer());
            TokenStream ts = new TokenStream(lexed.GetTokens().ToList());
            ts.ProgressChanged += ProgressChanged;
            CompilationUnit file = null;
            try
            {
                file = new Parser(ts).Parse();
                JObject obj = JObject.Parse(file.ToJSON());
                TreeNode parent = Json2Tree(obj);
                parent.Text = "Root";
                treeView1.Nodes.Add(parent);
            }
            catch (CompilerException e)
            {
                treeView1.Nodes.Add(Exception2Tree(e));
                fastColoredTextBox1.AddHint(new Range(fastColoredTextBox1, CharnoToPlace(this.fastColoredTextBox1, ts.charno), CharnoToPlace(this.fastColoredTextBox1, ts.charno)),e.ToString());
                
            }
            catch (Exception e)
            {
                treeView1.Nodes.Add(Exception2Tree(e));
            }
            ProgressChanged(1, 1);
            ProgressChanged(0, 1);
        }

        private TreeNode Exception2Tree(Exception e)
        {
            TreeNode root = new TreeNode(e.GetType()+" - "+e.Message);
            foreach (string l in e.StackTrace.Split('\n'))
            {
                root.Nodes.Add(new TreeNode(l));
            }
            return root;

        }

        private Place CharnoToPlace(FastColoredTextBoxNS.FastColoredTextBox tb, int charnoo)
        {
            int charno = charnoo - 1;
            int chrs = 0;
            int ls = 0;
            foreach (string l in tb.Lines)
            {
                if (charno < (chrs + (l.Length - 1)))
                {
                    return new Place(charno - ((l.Length - 1) + chrs), ls);
                }
                chrs += l.Length;
                ls++;
            }
            return new Place(-1, -1);
        }

        private TreeNode Json2Tree(JObject obj)
        {
            TreeNode parent = new TreeNode();
            foreach (var token in obj)
            {
                if (token.Key.ToString() == "Value") continue;
                if (token.Key.ToString() == "typeName") continue;
                parent.Text = token.Key.ToString();

                TreeNode child = new TreeNode();
                if (token.Key.ToString() == "children")
                {
                    try
                    {
                        child.Text = "(" + obj.GetValue("typeName").ToString() + ")";
                    }
                    catch
                    {
                        child.Text = "(...)";
                    }
                }
                else
                {
                    child.Text = token.Key.ToString();
                }

                if (token.Value.Type.ToString() == "Object")
                {
                    JObject o = (JObject)token.Value;
                    child = Json2Tree(o);
                    parent.Nodes.Add(child);
                }
                else if (token.Value.Type.ToString() == "Array")
                {
                    int ix = -1;
                    foreach (var itm in token.Value)
                    {
                        if (itm.Type.ToString() == "Object")
                        {
                            TreeNode objTN = new TreeNode();
                            ix++;

                            JObject o = (JObject)itm;
                            objTN = Json2Tree(o);
                            objTN.Text = "(...)";
                            try
                            {
                                objTN.Text = Limit(o.GetValue("Value").ToString());
                            }
                            catch
                            {
                            }
                            child.Nodes.Add(objTN);
                        }
                        else if (itm.Type.ToString() == "Array")
                        {
                            ix++;
                            TreeNode dataArray = new TreeNode();
                            foreach (var data in itm)
                            {
                                dataArray.Text = token.Key.ToString() + "[" + ix + "]";
                                dataArray.Nodes.Add(data.ToString());
                            }
                            child.Nodes.Add(dataArray);
                        }

                        else
                        {
                            child.Nodes.Add(itm.ToString());
                        }
                    }
                    parent.Nodes.Add(child);
                }
                else
                {
                    if (token.Value.ToString() == "")
                        child.Nodes.Add("N/A");
                    else
                        child.Nodes.Add(token.Value.ToString());
                    parent.Nodes.Add(child);
                }
            }
            return parent;

        }
        private string Limit(string str, int length = 120)
        {
            if (str.Length > length * 2)
            {
                return "(...)";
            }
            if (str.Length > length)
            {
                return str.Substring(0, length - 3) + "...";
            }
            return str;
        }

        private void ProgressChanged(int cur, int total)
        {
            this.progressBar1.Value = (Int32)(Math.Round((cur / (double)total)*100, 2)*100);
        }
    }
}
