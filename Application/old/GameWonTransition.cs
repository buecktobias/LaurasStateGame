namespace Application.Transitions;

public class GameWonTransition : AbstractTransition
{
    public override bool Matches(string input, IGameInformation gameInformation)
    {
        var wonWithPaper = gameInformation.PlayerInformation == "Papier" &&
                           gameInformation.OpponentInformation == "Stein";
        var wonWithStone = gameInformation.PlayerInformation == "Stein" &&
                           gameInformation.OpponentInformation == "Schere";
        var wonWithScissors = gameInformation.PlayerInformation == "Schere" &&
                              gameInformation.OpponentInformation == "Papier";
        return wonWithPaper || wonWithStone || wonWithScissors;
    }

    public override IState GetTargetState()
    {
        return RockPaperScissorStateFactory.GetQuitState();
    }

    public override string GetOutput()
    {
        return "Yeah Sie haben gewonnen!";
    }
}