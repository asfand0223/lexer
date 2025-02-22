using System.Text;

namespace MyLexer
{
    public class Lexer
    {
        private readonly string _code;
        private int _position;
        public List<string> _lexemes { get; }

        public Lexer(string code)
        {
            _code = code;
            _position = 0;
            _lexemes = new List<string>();
        }

        public bool IsIdentifierChar(char c)
        {
            return (c >= 'a' && c <= 'z')
                || (c >= 'A' && c <= 'Z')
                || (c >= '0' && c <= '9')
                || c == '_';
        }

        public bool IsIdentifierStartChar(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '_';
        }

        public void ReadIdentifier()
        {
            StringBuilder sb = new StringBuilder();
            while (_position < _code.Length && IsIdentifierChar(_code[_position]))
            {
                sb.Append(_code[_position++]);
            }
            _lexemes.Add(sb.ToString());
        }

        public bool IsStringLiteralStartChar(char c)
        {
            return c == '"';
        }

        public bool IsStringLiteralEndChar(char c)
        {
            return c == '"';
        }

        public void ReadStringLiteral()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_code[_position++]);
            while (_position < _code.Length && !IsStringLiteralEndChar(_code[_position]))
            {
                sb.Append(_code[_position++]);
            }
            if (_position < _code.Length)
            {
                sb.Append(_code[_position++]);
            }
            _lexemes.Add(sb.ToString());
        }

        public void Lex()
        {
            while (_position < _code.Length)
            {
                if (char.IsWhiteSpace(_code[_position]))
                {
                    _position++;
                    continue;
                }
                else if (IsIdentifierStartChar(_code[_position]))
                {
                    ReadIdentifier();
                }
                else if (IsStringLiteralStartChar(_code[_position]))
                {
                    ReadStringLiteral();
                }
                else
                {
                    _lexemes.Add(_code[_position].ToString());
                    _position++;
                }
            }
        }
    }
}
