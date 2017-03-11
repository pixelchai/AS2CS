using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS
{
    public class TokenStream
    {
        public List<Token> tokens = null;
        public int index { get; private set; } = 0;

        public TokenStream(List<Token> tokens)
        {
            this.tokens = new List<Token>();
            foreach (Token t in tokens)
            {
                if (!String.IsNullOrWhiteSpace(t.Value))
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
