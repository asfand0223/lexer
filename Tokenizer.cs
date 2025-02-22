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
                case "string":
                    return new Token(TokenType.STRING, lexeme);
                case "true":
                    return new Token(TokenType.BOOLEAN, lexeme);
                case "false":
                    return new Token(TokenType.BOOLEAN, lexeme);
                case "if":
                    return new Token(TokenType.IF, lexeme);
                case "else":
                    return new Token(TokenType.ELSE, lexeme);
                case "for":
                    return new Token(TokenType.FOR, lexeme);
                case "while":
                    return new Token(TokenType.WHILE, lexeme);
                case "(":
                    return new Token(TokenType.LPAREN, lexeme);
                case ")":
                    return new Token(TokenType.RPAREN, lexeme);
                case "{":
                    return new Token(TokenType.LBRACE, lexeme);
                case "}":
                    return new Token(TokenType.RBRACE, lexeme);
                case ";":
                    return new Token(TokenType.SEMICOLON, lexeme);
                case "=":
                    return new Token(TokenType.ASSIGN, lexeme);
                case "+":
                    return new Token(TokenType.ADD, lexeme);
                case "-":
                    return new Token(TokenType.SUBTRACT, lexeme);
                case "*":
                    return new Token(TokenType.MULTIPLY, lexeme);
                case "/":
                    return new Token(TokenType.DIVIDE, lexeme);
                case "++":
                    return new Token(TokenType.INCREMENT, lexeme);
                case "--":
                    return new Token(TokenType.DECREMENT, lexeme);
                case "==":
                    return new Token(TokenType.EQUALS, lexeme);
                case "<":
                    return new Token(TokenType.LESS_THAN, lexeme);
                case ">":
                    return new Token(TokenType.GREATER_THAN, lexeme);
                case "<=":
                    return new Token(TokenType.LESS_THAN_OR_EQUAL, lexeme);
                case ">=":
                    return new Token(TokenType.GREATER_THAN_OR_EQUAL, lexeme);
                case "||":
                    return new Token(TokenType.OR, lexeme);
                case "&&":
                    return new Token(TokenType.AND, lexeme);
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
