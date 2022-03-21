namespace Application;

public class OpponentsTurnState : AbstractState
{
    public override void CreateTransitions()
    {
        Transitions.Add(TransitionFactory.GetGameDrawTransition());
        Transitions.Add(TransitionFactory.GetGameLostTransition());
        Transitions.Add(TransitionFactory.GetGameWonTransition());
    }

    public override string GetIntroOutput()
    {
        return "Opponents turn";
    }

    private string GetRandom()
    {
        var random = new Random();
        var num = random.Next(0, 3);
        return new List<string> {"Schere", "Stein", "Papier"}[num];
    }

    public override IGameInformation Execute(IGameInformation gameInformation)
    {
        gameInformation.OpponentInformation = GetRandom();
        Console.WriteLine("Der Gegner hat " + gameInformation.OpponentInformation + " gewählt.");
        return gameInformation;
    }
}