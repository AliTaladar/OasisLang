using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisLang
{
    internal class Token
    {
        private string type;
        private string valueString;
        private double valueNumber;

        public Token(string type)
        {
            this.type = type;
        }

        public Token(string type, string value)
        {
            this.type = type;
            this.valueString = value;
        }

        public Token(string type, double value)
        {
            this.type = type;
            this.valueNumber = value;
        }

        public override string ToString()
        {
            switch (this.type)
            {
                case Oasis.TT_NUMBER:
                    return string.Format("{0}:{1}", this.type, this.valueNumber);
                default:
                    return string.Format("{0}", this.type);
            }

        }

    }
}
