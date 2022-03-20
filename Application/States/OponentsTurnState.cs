namespace Application;

public class OponentsTurnState : AbstractState
{
    public override void CreateTransitions()
    {
        this.Transitions.Add(_transitionFactory.GetGameDrawTransition());
        this.Transitions.Add(_transitionFactory.GetGameLostTransition());
        this.Transitions.Add(_transitionFactory.GetGameWonTransition());
    }

    public override string GetIntroOutput()
    {
        return "Opponents turn";
    }

    private string GetRandom()
    {
        var random = new Random();
        var num = random.Next(0, 3);
        return new List<string>() {"Schere", "Stein", "Papier"}[num];
    }

    public override  IGameInformation Execute(IGameInformation gameInformation)
    {
        gameInformation.OpponentInformation = GetRandom();
        Console.WriteLine("Der Gegner hat " + gameInformation.OpponentInformation + " gewählt.");
        return gameInformation;
    }

    public override string GetOutroOutput()
    {
        return "";
    }

    public override bool IsEndState()
    {
        return false;
    }
}