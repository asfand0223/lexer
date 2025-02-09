using MyLexer;
using MyLexer.Entities;

try
{
    string code = File.ReadAllText("script.w");
    Lexer lexer = new Lexer(code);
    Tokenizer tokenizer = new Tokenizer();
    lexer.Lex();
    tokenizer.Tokenize(lexer._lexemes);
    foreach (Token token in tokenizer._tokens)
    {
        Console.WriteLine(token.GetTokenType() + " => " + token.GetValue());
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}
