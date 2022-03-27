using Application.RockPaperScissors;

namespace Application.GameInformation;

public class RockPaperScissorGameInformation : IRockPaperScissorGameInformation
{
    public GameSymbol PlayerInformation { get; set; }
    public GameSymbol OpponentInformation { get; set; }
    public IGameInformation GetCopy()
    {
        return new RockPaperScissorGameInformation(){PlayerInformation = PlayerInformation,
            OpponentInformation = OpponentInformation};
    }
}