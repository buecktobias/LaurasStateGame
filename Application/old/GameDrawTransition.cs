namespace Application.Transitions;

public class GameDrawTransition : AbstractTransition
{
    public override bool Matches(string input, IGameInformation gameInformation)
    {
        return gameInformation.OpponentInformation == gameInformation.PlayerInformation;
    }

    public override IState GetTargetState()
    {
        return StateFactory.GetGameStartState();
    }

    public override string GetOutput()
    {
        return "Unentschieden ! Nächste Runde !";
    }
}