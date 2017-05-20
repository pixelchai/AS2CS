using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS
{
    public delegate void PrintProgress(int cur, int total);

    [System.Diagnostics.DebuggerStepThrough]
    public class TokenStream
    {
        public event PrintProgress ProgressChanged;
        public int ProgressUpdate = 5;
        public bool dontPrUpdt = false;

        public List<Token> tokens = null;
        public int charno { get; private set; } = 0;
        private int _index = 0;
        public int index
        {
            get { return _index; }
            set
            {
                _index = value;

                int dif = value - index;
                if (dif > 0)
                {
                    for (int i = 0; i < dif; i++)
                    {
                        charno += tokens[value - i].Value.Length;
                    }
                }
                if (!dontPrUpdt)
                {
                    if (value % ProgressUpdate == 0)
                    {
                        if (ProgressChanged != null)
                        {
                            ProgressChanged.Invoke(value, tokens.Count);
                        }
                    }
                }
            }
        } 

        public TokenStream(List<Token> tokens)
        {
            this.tokens = new List<Token>();
            foreach (Token t in tokens)
            {
                if (!String.IsNullOrWhiteSpace(t.Value) && !t.isType("Comment"))
                {
                    this.tokens.Add(t);
                }
            }
        }

        public Token nextOf(string s)
        {
            Token ret;
            this.increment();
            ret = this.getCur();
            while (!ret.isType(s))
            {
                this.increment();
                ret = this.getCur();
            }
            return ret;
        }

        public int iNextOf(string s)
        {
            int i = 0;
            Token ret;
            this.increment();
            i++;
            ret = this.getCur();
            while (!ret.isType(s))
            {
                this.increment();
                i++;
                ret = this.getCur();
            }
            return i;
        }

        public Token nextOfMatch(string s, string match)
        {
            Token ret;
            this.increment();
            ret = this.getCur();
            while (!ret.isType(s) && ret.Value != match)
            {
                this.increment();
                ret = this.getCur();
            }
            return ret;
        }

        public int iNextOfMatch(string s, string match)
        {
            int i = 0;
            Token ret;
            i++;
            this.increment();
            ret = this.getCur();
            while (!ret.isType(s) && ret.Value != match)
            {
                this.increment();
                i++;
                ret = this.getCur();
            }
            return i;
        }


        public Token nextOfX(string s)
        {
            Token ret;
            this.increment();
            ret = this.getCur();
            while (!ret.isTypeX(s))
            {
                this.increment();
                ret = this.getCur();
            }
            return ret;
        }

        public Token nextHas(string s)
        {
            Token ret;
            this.increment();
            ret = this.getCur();
            while (!ret.hasType(s))
            {
                this.increment();
                ret = this.getCur();
            }
            return ret;
        }

        public Token getCur()
        {
            return look(0);
        }

        public Token next()
        {
            try
            {
                return getCur();
            }
            finally
            {
                this.increment();
            }
        }

        public int increment(int x = 1)
        {
            index += x;
            return index;
        }

        public Token look(int off)
        {
            return tokens[index + off];
        }

        public int GetSave()
        {
            return index;
        }
        public void SetSave(int save)
        {
            this.index = save;
        }

        public Token GetAt(int index)
        {
            return tokens[index];
        }
    }
}
