using System;
using System.Collections.Generic;
using System.Text;

namespace OasisLang
{
    internal class Lexer
    {
        private string fileName;
        private string text;
        private Position pos;
        private char? currChar;

        public Lexer(string fileName, string text)
        {
            this.fileName = fileName;
            this.text = text;
            this.pos = new Position(-1, 0, -1, fileName, text);
            this.currChar = null;
            Advance();
        }

        private void Advance()
        {
            this.pos.Advance(this.currChar);
            this.currChar = this.pos.idx < this.text.Length ? this.text[this.pos.idx] : null;
        }

        public TokensHelper MakeTokens()
        {
            List<Token> tokens = new List<Token>();

            while (this.currChar != null)
            {
                if (char.IsWhiteSpace(this.currChar.Value))
                {
                    Advance();
                }
                else if (Oasis.Digits.IndexOf(this.currChar.Value) != -1)
                {
                    tokens.Add(MakeNumber());
                }
                else if (this.currChar == '+')
                {
                    tokens.Add(new Token(Oasis.TT_PLUS));
                    Advance();
                }
                else if (this.currChar == '-')
                {
                    tokens.Add(new Token(Oasis.TT_MINUS));
                    Advance();
                }
                else if (this.currChar == '*')
                {
                    tokens.Add(new Token(Oasis.TT_MUL));
                    Advance();
                }
                else if (this.currChar == '/')
                {
                    tokens.Add(new Token(Oasis.TT_DIV));
                    Advance();
                }
                else if (this.currChar == '(')
                {
                    tokens.Add(new Token(Oasis.TT_LPAREN));
                    Advance();
                }
                else if (this.currChar == ')')
                {
                    tokens.Add(new Token(Oasis.TT_RPAREN));
                    Advance();
                }
                else
                {
                    Position posStart = this.pos.Copy();
                    char character = this.currChar.Value;
                    Advance();
                    return new TokensHelper(posStart, this.pos, new List<Token>(), new IllegalCharError(posStart, this.pos, "'" + character + "'"));
                }
            }

            return new TokensHelper(posStart: null, posEnd: null, tokens, error: null);
        }

        private Token MakeNumber()
        {
            StringBuilder numStr = new StringBuilder();
            int dotCount = 0;

            while (this.currChar != null && (Oasis.Digits.IndexOf(this.currChar.Value) != -1 || this.currChar == '.'))
            {
                if (this.currChar == '.')
                {
                    if (dotCount == 1) break;
                    dotCount++;
                    numStr.Append(".");
                }
                else
                {
                    numStr.Append(this.currChar);
                }
                Advance();
            }

            return new Token(Oasis.TT_NUMBER, double.Parse(numStr.ToString()));
        }
    }
}