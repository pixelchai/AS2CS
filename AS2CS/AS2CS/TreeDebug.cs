using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AS2CS
{
    public partial class TreeDebug : Form
    {
        string json = null;
        public TreeDebug()
        {
            InitializeComponent();
        }

        public TreeDebug(string json)
        {
            this.json = json;
            InitializeComponent();
        }

        private void TreeDebug_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(json)) return;

            try
            {
                JObject obj = JObject.Parse(json);
                tvw_display.Nodes.Clear();
                TreeNode parent = Json2Tree(obj);
                parent.Text = "Root";
                tvw_display.Nodes.Add(parent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR\n\n"+ex.ToString());
            }
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
                        child.Text = "("+obj.GetValue("typeName").ToString()+")";
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
    }
}
