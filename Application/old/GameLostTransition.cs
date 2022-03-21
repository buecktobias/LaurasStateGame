namespace Application.Transitions;

public class GameLostTransition : AbstractTransition
{
    public override bool Matches(string input, IGameInformation gameInformation)
    {
        var wonWithPaper = gameInformation.PlayerInformation == "Papier" &&
                           gameInformation.OpponentInformation == "Stein";
        var wonWithStone = gameInformation.PlayerInformation == "Stein" &&
                           gameInformation.OpponentInformation == "Schere";
        var wonWithScissors = gameInformation.PlayerInformation == "Schere" &&
                              gameInformation.OpponentInformation == "Papier";
        var isDraw = gameInformation.PlayerInformation == gameInformation.OpponentInformation;
        return !wonWithPaper && !wonWithStone && !wonWithScissors &&
               !isDraw;
    }

    public override IState GetTargetState()
    {
        return RockPaperScissorStateFactory.GetQuitState();
    }

    public override string GetOutput()
    {
        return "Sie haben leider verloren!";
    }
}