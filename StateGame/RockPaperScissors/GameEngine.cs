namespace Application.RockPaperScissors;

public record SymbolPair(GameSymbol First, GameSymbol Second)
{
    public readonly GameSymbol First = First;
    public readonly GameSymbol Second = Second;

    public virtual bool Equals(SymbolPair? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return First == other.First && Second == other.Second;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int) First, (int) Second);
    }
}
public class GameEngine
{

    private IList<SymbolPair> WinsAgainstList()
    {
        return new List<SymbolPair>()
        {
            new (GameSymbol.Paper, GameSymbol.Stone),
            new (GameSymbol.Stone, GameSymbol.Scissor),
            new (GameSymbol.Scissor, GameSymbol.Paper)
        };
    }
    private bool IsDraw(GameSymbol gameSymbol1, GameSymbol gameSymbol2)
    {
        return gameSymbol1 == gameSymbol2;
    }
    public GameResult GetGameResult(GameSymbol gameSymbol1, GameSymbol gameSymbol2)
    {
        var hasWon = WinsAgainstList().Contains(new SymbolPair(gameSymbol1, gameSymbol2));
        if (hasWon) return GameResult.Won;
        if (IsDraw(gameSymbol1, gameSymbol2)) return GameResult.Draw;
        return GameResult.Lost;
    }
}