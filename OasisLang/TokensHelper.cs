using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OasisLang
{
    internal class TokensHelper
    {
        private Position posStart;
        private Position posEnd;
        public List<Token> tokens;
        public Error? error;

        public TokensHelper(Position posStart, Position posEnd, List<Token> tokens, Error? error)
        {
            this.posStart = posStart;
            this.posEnd = posEnd;
            this.tokens = tokens;
            this.error = error;
        }
    }
}