using MyLexer.Entities;

namespace MyLexer
{
    public class Tokenizer
    {
        public List<Token> _tokens { get; }

        public Tokenizer()
        {
            _tokens = new List<Token>();
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

        public Token CreateToken(string lexeme)
        {
            switch (lexeme)
            {
                case "int":
                    return new Token(TokenType.INT, lexeme);
                case "=":
                    return new Token(TokenType.EQUALS, lexeme);
                case ";":
                    return new Token(TokenType.SEMICOLON, lexeme);
                case "(":
                    return new Token(TokenType.LPAREN, lexeme);
                case ")":
                    return new Token(TokenType.RPAREN, lexeme);
                case "{":
                    return new Token(TokenType.LBRACE, lexeme);
                case "}":
                    return new Token(TokenType.RBRACE, lexeme);
                case string _ when int.TryParse(lexeme, out _):
                    return new Token(TokenType.INT_LITERAL, lexeme);
                case string s when !ContainsIllegalCharacters(s):
                    return new Token(TokenType.IDENTIFIER, lexeme);
                default:
                    if (lexeme.Length > 1 && lexeme[0] == '"' && lexeme[lexeme.Length - 1] == '"')
                    {
                        return new Token(
                            TokenType.STRING_LITERAL,
                            lexeme.Substring(1, lexeme.Length - 2)
                        );
                    }
                    return new Token(TokenType.ILLEGAL, lexeme);
            }
        }

        public void Tokenize(List<string> lexemes)
        {
            foreach (string lexeme in lexemes)
            {
                Token token = CreateToken(lexeme);
                _tokens.Add(token);
            }
        }
    }
}
