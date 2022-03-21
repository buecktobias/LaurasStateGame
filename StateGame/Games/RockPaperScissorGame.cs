using System.Runtime.CompilerServices;
using Application.GameInformation;
using Application.StateFactory;
using Application.States;

namespace Application.Games;

public class RockPaperScissorGame : AbstractGame<IRockPaperScissorGameInformation>
{
    public RockPaperScissorGame() : 
        base(RockPaperScissorStateFactory.GetInstance().GetGameStartState(),
            new RockPaperScissorGameInformation())
    {
    }
}