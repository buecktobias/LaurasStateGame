namespace Application;

public class GameWonTransition : AbstractTransition
{
    public override bool Matches(string input, IGameInformation gameInformation)
    {
        bool wonWithPaper = gameInformation.PlayerInformation == "Papier" &&
                            gameInformation.OpponentInformation == "Stein";
        bool wonWithStone = gameInformation.PlayerInformation == "Stein" &&
            gameInformation.OpponentInformation == "Schere";
        bool wonWithScissors = gameInformation.PlayerInformation == "Schere" &&
                               gameInformation.OpponentInformation == "Papier";
        return wonWithPaper || wonWithStone || wonWithScissors;
    }

    public override IGameInformation Execute(string input, IGameInformation gameInformation)
    {
        return gameInformation;
    }

    public override IState GetTargetState()
    {
        return this.StateFactory.GetQuitState();
    }

    public override string GetOutput()
    {
        return "Yeah Sie haben gewonnen!";
    }
}