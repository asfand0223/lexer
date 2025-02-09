using MyLexer.Entities;

namespace MyLexer
{
    public class Tokenizer
    {
        public Tokenizer() { }

        public Token Tokenize(string lexeme)
        {
            switch (lexeme)
            {
                case "int":
                    return new Token(TokenType.INT, lexeme);
                case "=":
                    return new Token(TokenType.EQUALS, lexeme);
                case ";":
                    return new Token(TokenType.SEMICOLON, lexeme);
                case string _ when int.TryParse(lexeme, out _):
                    return new Token(TokenType.INT_LITERAL, lexeme);
                case string s when !ContainsIllegalCharacters(s):
                    return new Token(TokenType.IDENTIFIER, lexeme);
                default:
                    return new Token(TokenType.ILLEGAL, lexeme);
            }
        }

        private bool ContainsIllegalCharacters(string lexeme)
        {
            foreach (char c in lexeme)
            {
                if (!char.IsLetterOrDigit(c) && c != '_')
                {
                    return true;
                }
            }
            return false;
        }
    }
}
