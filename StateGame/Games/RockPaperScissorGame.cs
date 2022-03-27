using Application.GameInformation;
using Application.RockPaperScissors;

namespace Application.Games;

public class RockPaperScissorGame : AbstractGame<IRockPaperScissorGameInformation>
{
    public RockPaperScissorGame() :
        base(RockPaperScissorStateFactory.GetInstance().GetGameStartState(),
            new RockPaperScissorGameInformation())
    {
    }
}