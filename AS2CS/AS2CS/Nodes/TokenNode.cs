﻿using Newtonsoft.Json;
using PygmentSharp.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Nodes
{
    public class TokenNode : Node
    {
        public enum VerificationMode
        {
            /// <summary>
            /// contains type
            /// </summary>
            Has,
            /// <summary>
            /// is type ordered (some variant of - is at least)
            /// </summary>
            Is,
            /// <summary>
            /// is type exclusive (this exact type)
            /// </summary>
            IsX,
        }

        public string type { get; private set; } = null;

        [JsonIgnore]
        public VerificationMode mode { get; private set; } = VerificationMode.Is;
        [JsonIgnore]
        public bool matched { get; private set; } = true;
        [JsonIgnore]
        public string val { get; private set; } = null;
        [JsonIgnore]
        public bool doMatchVal { get; private set; } = false;

        [JsonIgnore]
        public Token value = new Token();

        public override string GetValue()
        {
            return value.Value;
        }

        public TokenNode(TokenStream tokenStream, TokenType type, VerificationMode verificationMode = VerificationMode.Is) : base(tokenStream)
        {
            this.type = type.ToString();
            this.mode = verificationMode;
        }

        public TokenNode(TokenStream tokenStream, Token token, VerificationMode verificationMode = VerificationMode.Is) : base(tokenStream)
        {
            this.type = token.Type.ToString();
            this.mode = verificationMode;
        }

        public TokenNode(TokenStream tokenStream, string type, VerificationMode verificationMode = VerificationMode.Is) : base(tokenStream)
        {
            this.type = type;
            this.mode = verificationMode;
        }

        public TokenNode(TokenStream tokenStream, TokenType type, string val, VerificationMode verificationMode = VerificationMode.Is) : base(tokenStream)
        {
            this.type = type.ToString();
            this.mode = verificationMode;
            this.doMatchVal = true;
            this.val = val;
        }

        public TokenNode(TokenStream tokenStream, Token token, string val, VerificationMode verificationMode = VerificationMode.Is) : base(tokenStream)
        {
            this.type = token.Type.ToString();
            this.mode = verificationMode;
            this.doMatchVal = true;
            this.val = val;
        }

        public TokenNode(TokenStream tokenStream, string type, string val, VerificationMode verificationMode = VerificationMode.Is) : base(tokenStream)
        {
            this.type = type;
            this.mode = verificationMode;
            this.doMatchVal = true;
            this.val = val;
        }


        public override Node Select()
        {
            Token t = ts.getCur();
            switch (mode)
            {
                case VerificationMode.Has:
                    matched = t.hasType(type);
                    break;
                case VerificationMode.Is:
                    matched = t.isType(type);
                    break;
                case VerificationMode.IsX:
                    matched = t.isTypeX(type);
                    break;
            }
            if (matched)
            {
                if (doMatchVal)
                {
                    if (t.Value != val) return null;
                }
                value = t;
                ts.increment();
                return this;
            }
            else
            {
                return null;
            }
        }
    }
}