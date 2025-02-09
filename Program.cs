using MyLexer;

try
{
    Lexer lexer = new Lexer("script.w");
    lexer.Lex();
    lexer.DisplayTokens();
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}
