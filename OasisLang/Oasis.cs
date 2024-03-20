using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisLang
{
    internal class Oasis
    {
        public const string Digits = "123456789";
        public const string TT_NUMBER = "TT_NUM";
        public const string TT_PLUS = "PLUS";
        public const string TT_MINUS = "MINUS";
        public const string TT_MUL = "MUL";
        public const string TT_DIV = "DIV";
        public const string TT_LPAREN = "LPAREN";
        public const string TT_RPAREN = "RPAREN";

        public TokensHelper Run(string fileName, string text)
        {
            Lexer lexer = new Lexer(fileName, text);
            TokensHelper tokensHelper = lexer.MakeTokens();
            return tokensHelper;
        }

    }
}
