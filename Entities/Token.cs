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
        ASSIGN,
        LPAREN,
        RPAREN,
        LBRACE,
        RBRACE,
        SEMICOLON,
        IF,
        ELSE,
        WHILE,
        FOR,
        EQUALS,
        NOT_EQUALS,
        LESS_THAN,
        GREATER_THAN,
        LESS_THAN_OR_EQUAL,
        GREATER_THAN_OR_EQUAL,
        OR,
        AND,
        ADD,
        SUBTRACT,
        MULTIPLY,
        DIVIDE,
        MODULO,
        INCREMENT,
        DECREMENT,
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
