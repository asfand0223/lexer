namespace MyLexer.Entities
{
    public enum TokenType
    {
        ILLEGAL,
        IDENTIFIER,
        INT,
        INT_LITERAL,
        EQUALS,
        LPAREN,
        RPAREN,
        LBRACE,
        RBRACE,
        SEMICOLON,
    }

    public class Token
    {
        private TokenType _type;
        private string _value;

        public Token(TokenType tokenType, string value)
        {
            _type = tokenType;
            _value = value;
        }

        public TokenType GetTokenType()
        {
            return _type;
        }

        public string GetValue()
        {
            return _value;
        }
    }
}
