using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS
{
    public static class Utils
    {
        /// <summary>
        /// contains type
        /// </summary>
        public static bool hasType(this Token token, string type)
        {
            string[] t = type.Split('.');
            string[] act = token.Type.ToString().Split('.');
            foreach (string s in t)
            {
                if (!act.Contains(s)) return false;
            }
            return true;
        }

        /// <summary>
        /// is type ordered (some variant of - is at least)
        /// </summary>
        public static bool isType(this Token token, string type)
        {
            string[] act = token.Type.ToString().Split('.');
            string[] t = type.Split('.');

            for (int i = 0; i < t.Length; i++)
            {
                try
                {
                    if (t[i] != act[i])
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// is type exclusive (this exact type)
        /// </summary>
        public static bool isTypeX(this Token token, string type)
        {
            string[] act = token.Type.ToString().Split('.');
            string[] t = type.Split('.');

            if (act.Length != t.Length) return false;

            for (int i = 0; i < t.Length; i++)
            {
                try
                {
                    if (t[i] != act[i])
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public static string EscapedValue(this Token token)
        {
            return token.Value.Replace("\n", "\\n").Replace("\r", "\\r");
        }

        public static string TokenStreamLoc(TokenStream ts)
        {
            StringBuilder ret = new StringBuilder();
            for (int i = ts.index - 1; i > 0 && i > ts.index - 5; i--)
            {
                ret.Append(ts.GetAt(i).EscapedValue());
            }
            ret.Append(">>" + ts.getCur().EscapedValue() + "<<");
            for (int i = ts.index + 1; i < ts.tokens.Count && i < ts.index + 5; i++)
            {
                ret.Append(ts.GetAt(i).EscapedValue());
            }
            return ret.ToString();
        }

    }
}
