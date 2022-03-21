using Application.RockPaperScissors;

namespace Application.GameInformation;

public interface IRockPaperScissorGameInformation : IGameInformation
{
    public GameSymbol PlayerInformation { get; set; }
    public GameSymbol OpponentInformation { get; set; }
}