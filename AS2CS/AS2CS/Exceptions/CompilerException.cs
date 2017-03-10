using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2CS.Exceptions
{
    public class CompilerException : Exception
    {
        public CompilerException(TokenStream ts) : base(Utils.TokenStreamLoc(ts))
        {
        }

       
        public CompilerException(string message) : base(message)
        {
        }

        public CompilerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
