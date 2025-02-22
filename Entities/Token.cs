namespace MyLexer.Entities
{
    public enum TokenType
    {
        ILLEGAL,
        IDENTIFIER,
        INT,
        STRING,
        BOOLEAN,
        INT_LITERAL,
        STRING_LITERAL,
        EQUALS,
        LPAREN,
        RPAREN,
        LBRACE,
        RBRACE,
        SEMICOLON,
        IF,
        ELSE,
        WHILE,
        FOR,
        LESS_THAN,
        GREATER_THAN,
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
