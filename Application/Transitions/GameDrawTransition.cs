namespace Application;

public class GameDrawTransition : AbstractTransition
{
    public override bool Matches(string input, IGameInformation gameInformation)
    {
        return gameInformation.OpponentInformation == gameInformation.PlayerInformation;
    }

    public override IGameInformation Execute(string input, IGameInformation gameInformation)
    {
        return gameInformation;
    }

    public override IState GetTargetState()
    {
        return this.StateFactory.GetGameStartState();
    }

    public override string GetOutput()
    {
        return "Unentschieden ! Nächste Runde !";
    }
}