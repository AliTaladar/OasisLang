using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisLang
{
    internal class Error
    {
        private Position posStart;
        private Position posEnd;
        private string errorName;
        private string details;

        public Error(Position posStart, Position posEnd, string errorName, string details)
        {
            this.posStart = posStart;
            this.posEnd = posEnd;
            this.errorName = errorName;
            this.details = details;
        }

        public override string ToString()
        {
            return $"{errorName}: {details}" +
                   $"\nFile {posStart.fileName}, line {posStart.line + 1}";
        }
    }
}
