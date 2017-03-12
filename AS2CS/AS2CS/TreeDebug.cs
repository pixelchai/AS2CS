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
            //create the parent node
            TreeNode parent = new TreeNode();
            //loop through the obj. all token should be pair<key, value>
            foreach (var token in obj)
            {
                //change the display Content of the parent
                parent.Text = token.Key.ToString();

                //create the child node
                TreeNode child = new TreeNode();
                //child.Text = token.Key.ToString();
                if (token.Key.ToString() == "children")
                {
                    child.Text = "(...)";
                }
                else
                {
                    if (token.Key.ToString() == "typeName")
                    {
                        child.Text ="Type: "+ token.Value.ToString();
                    }
                    else {
                        if (token.Key.ToString() == "matchedValue")
                        {
                            //MessageBox.Show(parent.Text);
                            try
                            {
                                parent.Parent.Text = token.Value.ToString();
                            }
                            catch { }
                            child.Text = "Matched: " + token.Value.ToString();
                        }
                        else {
                            //MessageBox.Show(token.Key.ToString());
                            child.Text = token.Key.ToString();
                        }
                    }
                }
                //check if the value is of type obj recall the method
                if (token.Value.Type.ToString() == "Object")
                {
                    // child.Text = token.Key.ToString();
                    //create a new JObject using the the Token.value
                    JObject o = (JObject)token.Value;
                    //recall the method
                    child = Json2Tree(o);
                    //add the child to the parentNode
                    parent.Nodes.Add(child);
                }
                //if type is of array
                else if (token.Value.Type.ToString() == "Array")
                {
                    int ix = -1;
                    //  child.Text = token.Key.ToString();
                    //loop though the array
                    foreach (var itm in token.Value)
                    {
                        //check if value is an Array of objects
                        if (itm.Type.ToString() == "Object")
                        {
                            TreeNode objTN = new TreeNode();
                            //child.Text = token.Key.ToString();
                            //call back the method
                            ix++;

                            JObject o = (JObject)itm;
                            objTN = Json2Tree(o);
                            objTN.Text = "(...)";
                            //objTN.Text = o.ToString();
                            try
                            {
                                objTN.Text = GetValueDeep(o).ToString();
                            }
                            catch { }
                            child.Nodes.Add(objTN);
                            //parent.Nodes.Add(child);
                        }
                        //regular array string, int, etc
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
                    //if token.Value is not nested
                    // child.Text = token.Key.ToString();
                    //change the value into N/A if value == null or an empty string 
                    if (token.Value.ToString() == "")
                        child.Nodes.Add("N/A");
                    else
                        child.Nodes.Add(token.Value.ToString());
                    parent.Nodes.Add(child);
                }
            }
            return parent;

        }

        private JToken GetValueDeep(JObject o)
        {
            //if (o.Type != JTokenType.Array && o.Type != JTokenType.Object)
            //{
            //    return null;
            //}

            //JToken ret = null;
            //if (o.TryGetValue(search, out ret))
            //{
            //    return ret;
            //}
            //else
            //{
            //    foreach (JToken ch in o.())
            //    {
            //        GetValueDeep(ch, search);
            //    }
            //}

            foreach (JToken token in o.Descendants())
            {
                //try
                //{
                //    foreach (JObject content in token.Children<JObject>())
                //    {
                //        try
                //        {
                //            foreach (JProperty prop in content.Properties())
                //            {
                //                if (prop.Name == search)
                //                {
                //                    return prop.Value;
                //                }
                //            }
                //        }
                //        catch { }
                //    }
                //}
                //catch { }
                //MessageBox.Show(token.ToString());
                if (token.ToString().StartsWith("\"matchedValue\"")|| token.ToString().StartsWith("\"Matched\"")|| token.ToString().StartsWith("\"value\""))
                {
                    return token.ToString().Substring(token.ToString().IndexOf(":")+3,token.ToString().Length- token.ToString().IndexOf(":")-4);
                }
            }
            throw new Exception();
        }
    }
}
