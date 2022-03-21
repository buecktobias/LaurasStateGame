using Application.States;

namespace Application;

public class OpponentsTurnState : AbstractState
{
    public override void CreateTransitions()
    {
        Transitions.Add(RockPaperScissorTransitionFactory.GetGameDrawTransition());
        Transitions.Add(RockPaperScissorTransitionFactory.GetGameLostTransition());
        Transitions.Add(RockPaperScissorTransitionFactory.GetGameWonTransition());
    }

    public override string GetIntroOutput()
    {
        return "Opponents turn";
    }


    public override IGameInformation Execute(IGameInformation gameInformation)
    {
        gameInformation.OpponentInformation = GetRandom();
        Console.WriteLine("Der Gegner hat " + gameInformation.OpponentInformation + " gewählt.");
        return gameInformation;
    }

    private string GetRandom()
    {
        var random = new Random();
        var num = random.Next(0, 3);
        return new List<string> {"Schere", "Stein", "Papier"}[num];
    }
}