using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisLang
{
    internal class IllegalCharError : Error
    {
        public IllegalCharError(Position posStart, Position posEnd, string details)
        : base(posStart, posEnd, "Illegal Character", details)
        {
        }
    }
}
