namespace Application.RockPaperScissors;

public class SymbolInputReader
{
    public GameSymbol? ReadSymbol(string input)
    {
        return input switch
        {
            "Schere" => GameSymbol.Scissor,
            "Stein" => GameSymbol.Stone,
            "Papier" => GameSymbol.Paper,
            _ => null
        };
    }
}