using System.Text;
using MyLexer.Entities;

namespace MyLexer
{
    public class Lexer
    {
        private readonly StreamReader _streamReader;
        private readonly StringBuilder _buffer;
        private readonly List<Token> _tokens;
        private readonly Tokenizer _tokenizer;

        public Lexer(string fileName)
        {
            _streamReader = new StreamReader(fileName);
            _buffer = new StringBuilder();
            _tokens = new List<Token>();
            _tokenizer = new Tokenizer();
        }

        public void Lex()
        {
            while (_streamReader.Peek() != -1)
            {
                char c = (char)_streamReader.Peek();
                switch (c)
                {
                    case char _ when char.IsWhiteSpace(c):
                        if (_buffer.Length > 0)
                        {
                            _tokens.Add(_tokenizer.Tokenize(_buffer.ToString()));
                            _buffer.Clear();
                        }
                        break;
                    case char _ when !char.IsLetterOrDigit(c) && c != '_':
                        if (_buffer.Length > 0)
                        {
                            _tokens.Add(_tokenizer.Tokenize(_buffer.ToString()));
                            _buffer.Clear();
                        }
                        _tokens.Add(_tokenizer.Tokenize(c.ToString()));
                        break;
                    default:
                        _buffer.Append(c);
                        break;
                }
                _streamReader.Read();
            }
        }

        public void DisplayTokens()
        {
            foreach (Token token in _tokens)
            {
                Console.WriteLine(token.GetTokenType() + " => " + token.GetValue());
            }
        }
    }
}
