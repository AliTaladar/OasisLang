namespace OasisLang
{
    public class Position
    {
        public int idx;
        public int line;
        public int col;
        public string fileName;
        public string fileText;

        public Position(int idx, int line, int col, string fileName, string fileText)
        {
            this.idx = idx;
            this.line = line;
            this.col = col;
            this.fileName = fileName;
            this.fileText = fileText;
        }

        public Position Advance(char? currChar)
        {
            this.idx++;
            this.col++;
            if (currChar != null && currChar == '\n')
            {
                this.line++;
                this.col = 0;
            }
            return this;
        }

        public Position Copy()
        {
            return new Position(this.idx, this.line, this.col, this.fileName, this.fileText);
        }
    }
}